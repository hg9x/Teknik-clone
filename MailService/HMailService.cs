﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Teknik.MailService
{
    public class HMailService : MailService
    {
        private readonly hMailServer.Application _App;

        private string _Username { get; set; }
        private string _Password { get; set; }
        private string _Domain { get; set; }

        private string _CounterServer { get; set; }
        private string _CounterDatabase { get; set; }
        private string _CounterUsername { get; set; }
        private string _CounterPassword { get; set; }
        private int _CounterPort { get; set; }

        public HMailService(string username, string password, string domain, string counterServer, string counterDatabase, string counterUsername, string counterPassword, int counterPort)
        {
            _Username = username;
            _Password = password;
            _Domain = domain;

            _CounterServer = counterServer;
            _CounterDatabase = counterDatabase;
            _CounterUsername = counterUsername;
            _CounterPassword = counterPassword;
            _CounterPort = counterPort;

            _App = InitApp();
        }

        public override void CreateAccount(string username, string password, int size)
        {
            var domain = _App.Domains.ItemByName[_Domain];
            var newAccount = domain.Accounts.Add();
            newAccount.Address = username;
            newAccount.Password = password;
            newAccount.Active = true;
            newAccount.MaxSize = size;

            newAccount.Save();
        }

        public override bool AccountExists(string username)
        {
            try
            {
                GetAccount(username);
                // We didn't error out, so the email exists
                return true;
            }
            catch { }
            return false;
        }

        public override void Delete(string username)
        {
            throw new NotImplementedException();
        }

        public override void Enable(string username)
        {
            EditActivity(username, true);
        }

        public override void Disable(string username)
        {
            EditActivity(username, false);
        }

        public override void EditActivity(string username, bool active)
        {
            var account = GetAccount(username);
            account.Active = active;
            account.Save();
        }

        public override void EditMaxEmailsPerDay(string username, int maxPerDay)
        {
            //We need to check the actual git database
            MysqlDatabase mySQL = new MysqlDatabase(_CounterServer, _CounterDatabase, _CounterUsername, _CounterPassword, _CounterPort);
            string sql = @"INSERT INTO mailcounter.counts (qname, lastdate, qlimit, count) VALUES ({1}, NOW(), {0}, 0)
                                    ON DUPLICATE KEY UPDATE qlimit = {0}";
            mySQL.Execute(sql, new object[] { maxPerDay, username });
        }

        public override void EditMaxSize(string username, int size)
        {
            var account = GetAccount(username);
            account.MaxSize = size;
            account.Save();
        }

        public override void EditPassword(string username, string password)
        {
            var account = GetAccount(username);
            account.Password = password;
            account.Save();
        }

        public override DateTime LastActive(string username)
        {
            var account = GetAccount(username);
            return (DateTime)account.LastLogonTime;
        }

        private hMailServer.Application InitApp()
        {
            var app = new hMailServer.Application();
            app.Connect();
            app.Authenticate(_Username, _Password);

            return app;
        }

        private hMailServer.Account GetAccount(string username)
        {
            var domain = _App.Domains.ItemByName[_Domain];
            return domain.Accounts.ItemByAddress[username];
        }
    }
}