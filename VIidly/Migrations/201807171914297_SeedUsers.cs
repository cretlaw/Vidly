namespace VIidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a087a491-88f6-4d23-88ca-9229c1bda360', N'guest@gmail.com', 0, N'ACODywFUrd6KXXjsncMtYUPrtjbSh9d4Mu0sidKDxgfBGalnlWUJGms15naVYbIffw==', N'5c600075-cfe5-48b7-89dd-3beddf0a0bb6', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e2b92a72-d719-441f-b907-5b9579b1da0b', N'admin@gmail.com', 0, N'ACbGXE5QjVhZ0zUAts1PArbaEKdhALJafwkFr3ymcAhrQLKqW2Is5l64pSxLNCYGPQ==', N'da007c38-8716-4f8c-8002-f01018a25574', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8c8e51c9-da7a-45f7-84ac-482f17b18eb9', N'canManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e2b92a72-d719-441f-b907-5b9579b1da0b', N'8c8e51c9-da7a-45f7-84ac-482f17b18eb9')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
