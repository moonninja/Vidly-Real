namespace Vidly_Real.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES ('Hangover','Comedy','2018-01-20','2018-01-20',5)");
            Sql("INSERT INTO Movies (Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES ('Die Hard','Actino','2018-02-20','2018-02-20',5)");
            Sql("INSERT INTO Movies (Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES ('The Terminator','Action','2018-03-20','2018-03-20',5)");
            Sql("INSERT INTO Movies (Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES ('Toy Story','Family','2018-04-20','2018-04-20',5)");
            Sql("INSERT INTO Movies (Name,Genre,ReleaseDate,DateAdded,NumberInStock) VALUES ('Titanic','Romance','2018-05-20','2018-05-20',5)");
        }
        
        public override void Down()
        {
        }
    }
}
