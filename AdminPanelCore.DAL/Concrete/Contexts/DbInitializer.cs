using AdminPanelCore.ENTITIES.Abstarct.Enums;
using AdminPanelCore.ENTITIES.Concrete;
using System;
using System.Data.Entity;
using System.Linq;

namespace AdminPanelCore.DAL.Concrete.Contexts
{
    public class DbInitializer : IDatabaseInitializer<DatabaseContext>
    {
        public void InitializeDatabase(DatabaseContext context)
        {
            if (context.Database.Exists()) //Database varmı? Var ise kayıtları ekle
            {
                try
                {
                    #region CategoryTypes

                    if (!context.CategoryTypes.Any())
                    {
                        context.CategoryTypes.Add(new CategoryType()
                        {
                            CategoryTypeName = "Web",
                            Description = "Diğer Web Sayfaları [Ürünler vb.]"
                        });
                        context.SaveChanges();

                        context.CategoryTypes.Add(new CategoryType()
                        {
                            CategoryTypeName = "Web Kurumsal",
                            Description = "Web Kurumsal Sayfalar [Hakkımızda,İletişim vb.]"
                        });
                        context.SaveChanges();

                        context.CategoryTypes.Add(new CategoryType()
                        {
                            CategoryTypeName = "Admin Panel",
                            Description = "Admin Panel Sayfaları [Ürün Ekle,Slider Ekle,Hakkımızda Ekle vb.]"
                        });
                        context.SaveChanges();

                        context.CategoryTypes.Add(new CategoryType()
                        {
                            CategoryTypeName = "System Admin",
                            Description = "System Admin Sayfaları [Kategori Ekle,Kategori Tipi Ekle vb.]"
                        });
                        context.SaveChanges();
                    }

                    #endregion CategoryTypes

                    #region Roles

                    if (!context.Roles.Any())
                    {
                        context.Roles.Add(new Role()
                        {
                            RoleName = "SystemAdmin",
                        });
                        context.SaveChanges();

                        context.Roles.Add(new Role()
                        {
                            RoleName = "Admin",
                        });
                        context.SaveChanges();

                        context.Roles.Add(new Role()
                        {
                            RoleName = "User",
                        });
                        context.SaveChanges();
                    }

                    #endregion Roles

                    #region Users

                    if (!context.Users.Any())
                    {
                        context.Users.Add(new User()
                        {
                            CreatedDate = DateTime.Now,
                            CreatedUserID = 1,
                            DisplayOrder = 1,
                            Email = "sadmin@gmail.com",
                            IsDisplay = true,
                            FirstName = "system",
                            LastName = "admin",
                            Password = "12345",
                            RoleID = (int)Roles.SystemAdmin,
                            UserName = "sadmin",
                        });
                        context.SaveChanges();
                        context.Users.Add(new User()
                        {
                            CreatedDate = DateTime.Now,
                            CreatedUserID = 1,
                            DisplayOrder = 2,
                            Email = "admin@gmail.com",
                            IsDisplay = true,
                            FirstName = "admin",
                            LastName = "admin",
                            Password = "12345",
                            RoleID = (int)Roles.Admin,
                            UserName = "admin",
                        });
                        context.SaveChanges();
                        context.Users.Add(new User()
                        {
                            CreatedDate = DateTime.Now,
                            CreatedUserID = 1,
                            DisplayOrder = 3,
                            Email = "user@gmail.com",
                            IsDisplay = true,
                            FirstName = "user",
                            LastName = "name",
                            Password = "12345",
                            RoleID = (int)Roles.User,
                            UserName = "user",
                        });
                        context.SaveChanges();
                    }

                    #endregion Users

                    #region Categories

                    if (!context.Categories.Any())
                    {
                        context.Categories.Add(new Category()
                        {
                            CategoryName = "AnaSayfa",
                            CategoryTypeID = (int)CategoryTypes.WebMenu,
                            CreatedDate = DateTime.Now,
                            CreatedUserID = 1,
                            DisplayOrder = 1,
                            IsDisplay = true,
                            IsHomePage = true,
                            MetaDescription = "AnaSayfa",
                            MetaKeywords = "anasayfa",
                            SeoLink = "anasayfa",
                            Title = "AnaSayfa",
                        });
                        context.SaveChanges();
                    }

                    #endregion Categories

                    #region UserRoles

                    if (!context.UserRoles.Any())
                    {
                        context.UserRoles.Add(new UserRole()
                        {
                            CreatedDate = DateTime.Now,
                            CreatedUserID = 1,
                            RoleID = (int)Roles.SystemAdmin,
                            UserID = 1,
                        });
                        context.SaveChanges();
                        context.UserRoles.Add(new UserRole()
                        {
                            CreatedDate = DateTime.Now,
                            CreatedUserID = 1,
                            RoleID = (int)Roles.Admin,
                            UserID = 1,
                        });
                        context.SaveChanges();
                    }

                    #endregion UserRoles
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else //Yok ise
            {
                context.Database.Create(); //Database yok ise oluştur.
            }
        }
    }
}