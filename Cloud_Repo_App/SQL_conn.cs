using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;


namespace Cloud_Repo_App
{
    public class SQL_conn
    {
        readonly string salt = "*auK7LUbAB0HGQSV";
        readonly string sshServer = @"127.0.1.1";
        readonly string sshUser = @"lewis135";
        readonly string sshPassword = @"vmPass";
        readonly string databaseServer = @"127.0.0.1";
        readonly string databaseUser = @"disLogin";
        readonly string databasePassword = @"disCloud";

        public bool CheckConnection()
        {
            bool doesConnect = false;
            try
            {
                var (sshClient, localPort) = ConnectSsh(sshServer, sshUser, sshPassword, databaseServer: databaseServer);
                using (sshClient)
                {
                    if (sshClient.IsConnected)
                    {
                        Console.WriteLine("ssh is connected");
                    }
                    var builder = new MySqlConnectionStringBuilder
                    {
                        Server = @"127.0.0.1",
                        Port = localPort,
                        Database = @"accounts",
                        UserID = databaseUser,
                        Password = databasePassword,
                    };
                    using (var mysqlClient = new MySqlConnection(builder.ConnectionString))
                    {
                        mysqlClient.Open();
                        Console.WriteLine(mysqlClient.State.ToString());
                        if (mysqlClient.State == System.Data.ConnectionState.Open)
                        {
                            doesConnect = true;
                        }
                        else
                        {
                            doesConnect = false;
                        }
                        mysqlClient.Close();
                    }
                    sshClient.Disconnect();
                }
            }
            catch {
                Console.WriteLine("failed connection");
            }
            
            return doesConnect;
        }

        public bool CheckIfUserExists(string username)
        {
            bool doesExist = false;
            var (sshClient, localPort) = ConnectSsh(sshServer, sshUser, sshPassword, databaseServer: databaseServer);
            using (sshClient)
            {
                var builder = new MySqlConnectionStringBuilder
                {
                    Server = @"127.0.0.1",
                    Port = localPort,
                    Database = @"accounts",
                    UserID = databaseUser,
                    Password = databasePassword,
                };
                using (var mysqlClient = new MySqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine(mysqlClient.State.ToString());
                    string getUsernames = "SELECT * FROM users WHERE username='"+username+"'";
                    MySqlCommand cmd = new MySqlCommand(getUsernames, mysqlClient);
                    mysqlClient.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        //reader.Read();
                        //Console.WriteLine(reader.GetString(0));
                        doesExist = true;
                    }
                    else
                    {
                        doesExist = false;
                    }
                    reader.Close();
                    mysqlClient.Close();
                }
                sshClient.Disconnect();           
            }
            return doesExist;
        }

        public bool CheckIfEmailExists(string email)
        {
            bool doesExist = false;
            var (sshClient, localPort) = ConnectSsh(sshServer, sshUser, sshPassword, databaseServer: databaseServer);
            using (sshClient)
            {
                var builder = new MySqlConnectionStringBuilder
                {
                    Server = @"127.0.0.1",
                    Port = localPort,
                    Database = @"accounts",
                    UserID = databaseUser,
                    Password = databasePassword,
                };
                using (var mysqlClient = new MySqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine(mysqlClient.State.ToString());
                    string getEmails = "SELECT * FROM users WHERE email='" + email + "'";
                    MySqlCommand cmd = new MySqlCommand(getEmails, mysqlClient);
                    mysqlClient.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        doesExist = true;
                    }
                    else
                    {
                        doesExist = false;
                    }
                    reader.Close();
                    mysqlClient.Close();
                }
                sshClient.Disconnect();
            }
            return doesExist;
        }

        public void UploadFile(string filePath, string fileName, string userName)
        {
            using (SftpClient sftp = new SftpClient(@"127.0.0.1", @"lewis135", @"vmPass"))
            {
                try
                {
                    sftp.Connect();

                    using (var fileStream = System.IO.File.OpenRead(filePath))
                    {
                        sftp.ChangeDirectory("Repo_Storage/" + userName);
                        sftp.UploadFile(fileStream, fileName);
                    }
                    sftp.Disconnect();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                }
            }
        }

        public void DownloadFile(string destination, string downloadFile, string userName)
        {
            using (SftpClient sftp = new SftpClient(@"127.0.0.1", @"lewis135", @"vmPass"))
            {
                try
                {
                    sftp.Connect();

                    using (var fileStream = System.IO.File.OpenWrite(destination + @"\\" + downloadFile))
                    {
                        sftp.ChangeDirectory("Repo_Storage/" + userName);
                        sftp.DownloadFile(downloadFile, fileStream);
                    }
                    sftp.Disconnect();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                }
            }
        }

        public List<String> getFileList(string userName)
        {
            List<String> files = new List<string>();
            using (SftpClient sftp = new SftpClient(@"127.0.0.1", @"lewis135", @"vmPass"))
            {
                try
                {
                    sftp.Connect();
                    sftp.ChangeDirectory("Repo_Storage/" + userName);
                    foreach(var entry in sftp.ListDirectory("."))
                    {                    
                        if (!entry.IsDirectory)
                        {
                            files.Add(entry.Name);
                        }
                    }

                    sftp.Disconnect();

                 
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                }
                return files;
            }          
        }

        public void AddUser(string username, string name, string email, string password)
        {
            var (sshClient, localPort) = ConnectSsh(sshServer, sshUser, sshPassword, databaseServer: databaseServer);
            using (sshClient)
            {
                var builder = new MySqlConnectionStringBuilder
                {
                    Server = @"127.0.0.1",
                    Port = localPort,
                    Database = @"accounts",
                    UserID = databaseUser,
                    Password = databasePassword,
                };
                using (var mysqlClient = new MySqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine(mysqlClient.State.ToString());
                    string insertNewUser = "INSERT INTO users (username, name, email, password) VALUES ('"+username+"','"+name+"','"+email+"','"+password+"')";
                    MySqlCommand cmd = new MySqlCommand(insertNewUser, mysqlClient);
                    mysqlClient.Open();
                    cmd.ExecuteNonQuery();
                    mysqlClient.Close();
                }
                
                sshClient.RunCommand("mkdir Repo_Storage/" + username.ToString());


                sshClient.Disconnect();
            }
        }

        public bool ValidatePassword(string password)
        {
            bool doesExist = false;
            var (sshClient, localPort) = ConnectSsh(sshServer, sshUser, sshPassword, databaseServer: databaseServer);
            using (sshClient)
            {
                var builder = new MySqlConnectionStringBuilder
                {
                    Server = @"127.0.0.1",
                    Port = localPort,
                    Database = @"accounts",
                    UserID = databaseUser,
                    Password = databasePassword,
                };
                using (var mysqlClient = new MySqlConnection(builder.ConnectionString))
                {
                    Console.WriteLine(mysqlClient.State.ToString());
                    string getEmails = "SELECT * FROM users WHERE password='" + password + "'";
                    MySqlCommand cmd = new MySqlCommand(getEmails, mysqlClient);
                    mysqlClient.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        doesExist = true;
                    }
                    else
                    {
                        doesExist = false;
                    }
                    reader.Close();
                    mysqlClient.Close();
                }
                sshClient.Disconnect();
            }
            return doesExist;
        }

        public string CreateHashedPassword(string password, string username)
        {
            string seasoning = salt + username;
            byte[] newSalt = Encoding.ASCII.GetBytes(seasoning);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, newSalt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(newSalt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        public static (SshClient SshClient, uint Port) ConnectSsh(string sshHostName, string sshUserName, string sshPassword = null,
        string sshKeyFile = null, string sshPassPhrase = null, int sshPort = 22, string databaseServer = "localhost", int databasePort = 3306)
        {
            // check arguments
            if (string.IsNullOrEmpty(sshHostName))
                throw new ArgumentException($"{nameof(sshHostName)} must be specified.", nameof(sshHostName));
            if (string.IsNullOrEmpty(sshHostName))
                throw new ArgumentException($"{nameof(sshUserName)} must be specified.", nameof(sshUserName));
            if (string.IsNullOrEmpty(sshPassword) && string.IsNullOrEmpty(sshKeyFile))
                throw new ArgumentException($"One of {nameof(sshPassword)} and {nameof(sshKeyFile)} must be specified.");
            if (string.IsNullOrEmpty(databaseServer))
                throw new ArgumentException($"{nameof(databaseServer)} must be specified.", nameof(databaseServer));

            // define the authentication methods to use (in order)
            var authenticationMethods = new List<AuthenticationMethod>();
            if (!string.IsNullOrEmpty(sshKeyFile))
            {
                authenticationMethods.Add(new PrivateKeyAuthenticationMethod(sshUserName,
                    new PrivateKeyFile(sshKeyFile, string.IsNullOrEmpty(sshPassPhrase) ? null : sshPassPhrase)));
            }
            if (!string.IsNullOrEmpty(sshPassword))
            {
                authenticationMethods.Add(new PasswordAuthenticationMethod(sshUserName, sshPassword));//.Dump()) doesnt work with my version;
            }

            // connect to the SSH server
            var sshClient = new SshClient(new ConnectionInfo(sshHostName, sshPort, sshUserName, authenticationMethods.ToArray()));
            try
            {
                sshClient.Connect();
            }
            catch
            {
                //this is used to allow functions to use this unsuccessfully
            }

            // forward a local port to the database server and port, using the SSH server
            var forwardedPort = new ForwardedPortLocal("127.0.0.1", databaseServer, (uint)databasePort);
            sshClient.AddForwardedPort(forwardedPort);
            forwardedPort.Start();

            return (sshClient, forwardedPort.BoundPort);
        }
    }
}
