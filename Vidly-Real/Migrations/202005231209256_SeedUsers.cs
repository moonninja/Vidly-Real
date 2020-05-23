namespace Vidly_Real.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'24d3ed74-0821-4442-83dc-d4641cee8b21', N'admin@vidly.com', 0, N'AOpKcEgh12szNDTsqjqrX7GBevH8QP3znBaoj3uy34emyT74uVLVCM9dik2CjB64zg==', N'd96fafa3-3644-457a-b8a3-ed88f7b8219d', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'93c426da-5b91-44d2-97fa-c65c0659a298', N'guest@vidly.com', 0, N'AMe/FPo2fB2TSlFKFLEp3bFNlKsqmx5o3SKpZdVUSbK6FeYmMtzxrtJuv7yZHyG8cg==', N'ff0ee3ec-5749-44af-ab0d-c78752be5f26', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7a82acf2-8dd3-4e6d-86d7-1ad552215d18', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'24d3ed74-0821-4442-83dc-d4641cee8b21', N'7a82acf2-8dd3-4e6d-86d7-1ad552215d18')

");
        }
        
        public override void Down()
        {
        }
    }
}
