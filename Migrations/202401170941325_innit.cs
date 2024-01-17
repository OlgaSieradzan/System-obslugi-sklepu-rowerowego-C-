namespace Final_project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class innit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        Id_bike = c.String(nullable: false, maxLength: 128),
                        Company = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Model = c.String(),
                        Size = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        StoringDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Database_bikes_Db_BikesId = c.Int(),
                        Database_bikes_Db_BikesId1 = c.Int(),
                        Database_bikes_Db_BikesId2 = c.Int(),
                        Database_bikes_Db_BikesId3 = c.Int(),
                    })
                .PrimaryKey(t => t.Id_bike)
                .ForeignKey("dbo.Database_bikes", t => t.Database_bikes_Db_BikesId)
                .ForeignKey("dbo.Database_bikes", t => t.Database_bikes_Db_BikesId1)
                .ForeignKey("dbo.Database_bikes", t => t.Database_bikes_Db_BikesId2)
                .ForeignKey("dbo.Database_bikes", t => t.Database_bikes_Db_BikesId3)
                .Index(t => t.Database_bikes_Db_BikesId)
                .Index(t => t.Database_bikes_Db_BikesId1)
                .Index(t => t.Database_bikes_Db_BikesId2)
                .Index(t => t.Database_bikes_Db_BikesId3);
            
            CreateTable(
                "dbo.Database_bikes",
                c => new
                    {
                        Db_BikesId = c.Int(nullable: false, identity: true),
                        Databasename = c.String(),
                    })
                .PrimaryKey(t => t.Db_BikesId);
            
            CreateTable(
                "dbo.Database_clients",
                c => new
                    {
                        Db_ClientsId = c.Int(nullable: false, identity: true),
                        DatabaseName = c.String(),
                    })
                .PrimaryKey(t => t.Db_ClientsId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id_client = c.String(nullable: false, maxLength: 128),
                        City = c.String(),
                        Street = c.String(),
                        Code = c.String(),
                        Country = c.String(),
                        CompanyName = c.String(),
                        Nip = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Gender = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Database_clients_Db_ClientsId = c.Int(),
                        Database_clients_Db_ClientsId1 = c.Int(),
                        Database_clients_Db_ClientsId2 = c.Int(),
                        Database_clients_Db_ClientsId3 = c.Int(),
                    })
                .PrimaryKey(t => t.Id_client)
                .ForeignKey("dbo.Database_clients", t => t.Database_clients_Db_ClientsId)
                .ForeignKey("dbo.Database_clients", t => t.Database_clients_Db_ClientsId1)
                .ForeignKey("dbo.Database_clients", t => t.Database_clients_Db_ClientsId2)
                .ForeignKey("dbo.Database_clients", t => t.Database_clients_Db_ClientsId3)
                .Index(t => t.Database_clients_Db_ClientsId)
                .Index(t => t.Database_clients_Db_ClientsId1)
                .Index(t => t.Database_clients_Db_ClientsId2)
                .Index(t => t.Database_clients_Db_ClientsId3);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id_tran = c.String(nullable: false, maxLength: 128),
                        Invoice = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Client_Id_client = c.String(maxLength: 128),
                        Database_transaction_Db_TranId = c.Int(),
                        Database_transaction_Db_TranId1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id_tran)
                .ForeignKey("dbo.Clients", t => t.Client_Id_client)
                .ForeignKey("dbo.Database_transaction", t => t.Database_transaction_Db_TranId)
                .ForeignKey("dbo.Database_transaction", t => t.Database_transaction_Db_TranId1)
                .Index(t => t.Client_Id_client)
                .Index(t => t.Database_transaction_Db_TranId)
                .Index(t => t.Database_transaction_Db_TranId1);
            
            CreateTable(
                "dbo.Database_transaction",
                c => new
                    {
                        Db_TranId = c.Int(nullable: false, identity: true),
                        Databasename = c.String(),
                    })
                .PrimaryKey(t => t.Db_TranId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Database_transaction_Db_TranId1", "dbo.Database_transaction");
            DropForeignKey("dbo.Transactions", "Database_transaction_Db_TranId", "dbo.Database_transaction");
            DropForeignKey("dbo.Transactions", "Client_Id_client", "dbo.Clients");
            DropForeignKey("dbo.Clients", "Database_clients_Db_ClientsId3", "dbo.Database_clients");
            DropForeignKey("dbo.Clients", "Database_clients_Db_ClientsId2", "dbo.Database_clients");
            DropForeignKey("dbo.Clients", "Database_clients_Db_ClientsId1", "dbo.Database_clients");
            DropForeignKey("dbo.Clients", "Database_clients_Db_ClientsId", "dbo.Database_clients");
            DropForeignKey("dbo.Bikes", "Database_bikes_Db_BikesId3", "dbo.Database_bikes");
            DropForeignKey("dbo.Bikes", "Database_bikes_Db_BikesId2", "dbo.Database_bikes");
            DropForeignKey("dbo.Bikes", "Database_bikes_Db_BikesId1", "dbo.Database_bikes");
            DropForeignKey("dbo.Bikes", "Database_bikes_Db_BikesId", "dbo.Database_bikes");
            DropIndex("dbo.Transactions", new[] { "Database_transaction_Db_TranId1" });
            DropIndex("dbo.Transactions", new[] { "Database_transaction_Db_TranId" });
            DropIndex("dbo.Transactions", new[] { "Client_Id_client" });
            DropIndex("dbo.Clients", new[] { "Database_clients_Db_ClientsId3" });
            DropIndex("dbo.Clients", new[] { "Database_clients_Db_ClientsId2" });
            DropIndex("dbo.Clients", new[] { "Database_clients_Db_ClientsId1" });
            DropIndex("dbo.Clients", new[] { "Database_clients_Db_ClientsId" });
            DropIndex("dbo.Bikes", new[] { "Database_bikes_Db_BikesId3" });
            DropIndex("dbo.Bikes", new[] { "Database_bikes_Db_BikesId2" });
            DropIndex("dbo.Bikes", new[] { "Database_bikes_Db_BikesId1" });
            DropIndex("dbo.Bikes", new[] { "Database_bikes_Db_BikesId" });
            DropTable("dbo.Database_transaction");
            DropTable("dbo.Transactions");
            DropTable("dbo.Clients");
            DropTable("dbo.Database_clients");
            DropTable("dbo.Database_bikes");
            DropTable("dbo.Bikes");
        }
    }
}
