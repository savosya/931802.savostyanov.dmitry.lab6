using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace lab6.Models
{
    public class ForumContext : DbContext
    {
        public DbSet<UserModel> Users { get;set; }
        public DbSet<ForumCategoryModel> ForumCategories { get; set; }
        public DbSet<TopicModel> Topics { get; set; }
        public DbSet<ReplyModel> Replies { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<PictureModel> Pictures { get; set; }
        public DbSet<FolderModel> Folders { get; set; }
        public DbSet<FileModel> Files { get; set; }


        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleModel>().HasData(
                new RoleModel { Id = 1, Name = "admin" },
                new RoleModel { Id = 2, Name = "user" } );

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel
                {
                    Id = 1,
                    Email = "admin@mail.ru",
                    Password = "admin",
                    RoleId = 1
                },
                new UserModel
                {
                    Id = 2,
                    Email = "user@mail.ru",
                    Password = "user",
                    RoleId = 2
                },
                new UserModel
                {
                    Id = 3,
                    Email = "hater@mail.ru",
                    Password = "hater",
                    RoleId = 2
                },
                new UserModel
                {
                    Id = 4,
                    Email = "sibarit@mail.ru",
                    Password = "sibarit",
                    RoleId = 2
                },
                new UserModel
                {
                    Id = 5,
                    Email = "greta@mail.ru",
                    Password = "greta",
                    RoleId = 2
                });

            modelBuilder.Entity<ForumCategoryModel>().HasData(
                new ForumCategoryModel
                {
                    Id = 1,
                    Name = "Cars",
                    Description = "A place on the interwebs where people get to talk about how shitty Civics are and race other people based on who can name more mods for their car than the other person."
                },
                new ForumCategoryModel 
                {
                    Id = 2,
                    Name = "Flowers",
                    Description = "God keep you"
                },
                new ForumCategoryModel
                {
                    Id = 3,
                    Name = "SAUCES",
                    Description = "A NEW SUBJ FOR SAUCES HERE"
                });

            modelBuilder.Entity<PictureModel>().HasData(
                new PictureModel
                {
                    Id = 1,
                    Name = "HotSauce1",
                    Image = ReadFile("wwwroot/img/HotSauce1.jpg"),
                    ReplyModelId = 1
                },
                new PictureModel
                {
                    Id = 2,
                    Name = "frice",
                    Image = ReadFile("wwwroot/img/frice.jpg"),
                    ReplyModelId = 1
                },
                new PictureModel
                {
                    Id = 3,
                    Name = "carhate",
                    Image = ReadFile("wwwroot/img/carhate.jpg"),
                    TopicModelId = 4
                },
                new PictureModel
                {
                    Id = 4,
                    Name = "dogge",
                    Image = ReadFile("wwwroot/img/dogge.jpg"),
                    ReplyModelId = 10
                },
                new PictureModel
                {
                    Id = 5,
                    Name = "import",
                    Image = ReadFile("wwwroot/img/import.jpg"),
                    ReplyModelId = 5
                },
                new PictureModel
                {
                    Id = 6,
                    Name = "rain",
                    Image = ReadFile("wwwroot/img/rain.jpg"),
                    TopicModelId = 5
                },
                new PictureModel
                {
                    Id = 7,
                    Name = "gard",
                    Image = ReadFile("wwwroot/img/gard.jpg"),
                    TopicModelId = 5
                },
                new PictureModel
                {
                    Id = 8,
                    Name = "sleepy",
                    Image = ReadFile("wwwroot/img/sleepy.jpg"),
                    TopicModelId = 5
                },
                new PictureModel
                {
                    Id = 9,
                    Name = "sunset",
                    Image = ReadFile("wwwroot/img/sunset.jpg"),
                    ReplyModelId = 8
                });

            modelBuilder.Entity<TopicModel>().HasData(
                new TopicModel
                {
                    Id = 1,
                    Title = "Hot Sauce",
                    Description = "What's your top 3 hot sauces?",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    ReplyCount = 4,
                    ForumId = 1,
                    AuthorId = 4,
                    LastReplyId = 4
                },
                new TopicModel
                {
                    Id = 2,
                    Title = "Roses",
                    Description = "Roses are red violets are blue...",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    ReplyCount = 4,
                    ForumId = 2,
                    AuthorId = 2,
                    LastReplyId = 10,
                    PictureCount = 0
                },
                new TopicModel
                {
                    Id = 3,
                    Title = "9-ka da best",
                    Description = "normal'no edet",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    ReplyCount = 0,
                    ForumId = 1,
                    AuthorId = 2
                },
                new TopicModel
                {
                    Id = 4,
                    Title = "I HATE CARS",
                    Description = "THE POLLUION IS CRAZY. WE MUST STOP IT WITH ALL COST!",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    ReplyCount = 1,
                    ForumId = 1,
                    AuthorId = 3,
                    LastReplyId = 11,
                    PictureCount = 1
                },
                new TopicModel
                {
                    Id = 5,
                    Title = "The bees",
                    Description = "The bees my bees make my flowers blossom",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    ReplyCount = 0,
                    ForumId = 2,
                    AuthorId = 4,
                    PictureCount = 3
                },
                new TopicModel
                 {
                     Id = 6,
                     Title = "Lexus IS500 - Redline: First Look",
                     Description = "Check this out!! https://www.youtube.com/watch?v=sgoht5YeMAI",
                     DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                     DateEdited = DateTime.Now,
                     ReplyCount = 2,
                     ForumId = 3,
                     AuthorId = 3,
                    LastReplyId = 6
                 });

            modelBuilder.Entity<ReplyModel>().HasData(
                new ReplyModel
                {
                    Id = 1,
                    Text = "My favorite local sauce. Definitely not the hottest habanero sauce, but amazing garlicky. Very versatile. Goes well on anything.",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 1,
                    AuthorId = 3,
                    PictureCount = 2
                },
                new ReplyModel
                {
                    Id = 2,
                    Text = "Have you tried Marie Sharp's? I really like Cry Baby Craig's, but I found it to be very similar to Marie Sharp's and I liked the MS a little better. Both great sauces though!",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 1,
                    AuthorId = 2,
                    PictureCount = 0
                },
                new ReplyModel
                {
                    Id = 3,
                    Text = "Have not! Will certainly grab some!",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 1,
                    AuthorId = 3,
                    PictureCount = 0
                },
                new ReplyModel
                {
                    Id = 4,
                    Text = "What the hell is going on here? I guess we need a new subj for sauces...",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 1,
                    AuthorId = 1,
                    PictureCount = 0
                },
                new ReplyModel
                {
                    Id = 5,
                    Text = "Awesome stuff brother!",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 6,
                    AuthorId = 2,
                    PictureCount = 1
                 },
                new ReplyModel
                {
                    Id = 6,
                    Text = "Really!?",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 6,
                    AuthorId = 1,
                    PictureCount = 0
                },
                new ReplyModel
                {
                    Id = 7,
                    Text = "...wine costs less than dinner for two",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 2,
                    AuthorId = 3,
                    PictureCount = 0
                },
                new ReplyModel
                {
                    Id = 8,
                    Text = "...I really love my dog but you are OK too.",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 2,
                    AuthorId = 4,
                    PictureCount = 1
                },
                new ReplyModel
                {
                    Id = 9,
                    Text = "Wait, aren't violets violet?",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 2,
                    AuthorId = 1,
                    PictureCount = 0
                },
                new ReplyModel
                {
                    Id = 10,
                    Text = "Roses are red, bushes are red, trees are red... I set your garden on fire.",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 2,
                    AuthorId = 3,
                    PictureCount = 1
                },
                new ReplyModel
                {
                    Id = 11,
                    Text = "yes, The Earth is going to the end, but we have only 1 chance if we alltogether as people get on that high vibration and start meditating. We need to be emotionally involved in nature. In order to raise your emotional and spiritual vibration or how they say wake up ur inner animal, yes to become an animal you need to stop eating meat and let the animals live peacfully with people. we are animals just like cats or rabbits, but spiritually we are not. i feel like animals are more human than humans are. soooo yes, people are cruel animals and normal animals, like birds or dogs are need to be saved. If i were a president i would make my liberty-army kill all others who disagree because im right.",
                    DateCreated = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"),
                    DateEdited = DateTime.Now,
                    TopicId = 4,
                    AuthorId = 5,
                    PictureCount = 0
                });           

            modelBuilder.Entity<FolderModel>().HasData(
                new FolderModel
                {
                    Id = 1,
                    Name = "Root"
                });
        }


        // forum entity terminator
       
        public ReplyModel DeleteAllPicturesInReply(ReplyModel reply)
        {
            if (reply.PictureCount != 0)
            {
                foreach (PictureModel pic in reply.Pictures.ToList())
                {
                    reply.Pictures.Remove(pic);
                    this.Pictures.Remove(pic);
                }
            }
            return reply;
        }
        public TopicModel DeleteAllPicturesInTopic(TopicModel topic)
        {
            if (topic.PictureCount != 0)
            {
                foreach (PictureModel pic in topic.Pictures.ToList())
                {
                    topic.Pictures.Remove(pic);
                    this.Pictures.Remove(pic);
                }
            }
            return topic;
        }
        public TopicModel DeleteAllRepliesInTopic(TopicModel topic)
        {
            if(topic.ReplyCount != 0)
            {
                foreach (ReplyModel reply in topic.Replies.ToList())
                {
                    DeleteReply(reply, topic);
                }
            }
            return topic;
        }
        public ForumCategoryModel DeleteAllTopicsInCategory(ForumCategoryModel forumCategory)
        {
            if (forumCategory.Topics.Any())
            {
                foreach (TopicModel topic in forumCategory.Topics.ToList())
                {
                    DeleteTopic(topic);
                }
            }
            return forumCategory;
        }

        public void DeleteForumCategory(ForumCategoryModel forumCategory)
        {
            forumCategory = DeleteAllTopicsInCategory(forumCategory);
            this.ForumCategories.Remove(forumCategory);
        }
        public void DeleteReply(ReplyModel reply, TopicModel topic)
        {
            reply = DeleteAllPicturesInReply(reply);
            topic.Replies.Remove(reply);
            topic.ReplyCount--;
            this.Replies.Remove(reply);
        }
        public void DeleteTopic(TopicModel topic)
        {
            topic = DeleteAllRepliesInTopic(topic);
            topic = DeleteAllPicturesInTopic(topic);
            this.Topics.Remove(topic);
        }
        public void DeleteFile(FileModel file)
        {
           FolderModel folder = this.Folders.FirstOrDefault(x => x.Id == file.FolderId);
           folder.Files.Remove(file);
           this.Files.Remove(file);
        }
        public void DeleteFolder(FolderModel folder)
        {
            FolderModel ParentFolder = this.Folders.FirstOrDefault(x => x.Id == folder.ParentFolderId);
            ParentFolder.Folders.Remove(folder);
            this.Folders.Remove(folder);
        }

        public void DeleteFolderDirectory(FolderModel folder)
        {
            if (folder.Files.Any())
            {
                foreach(FileModel file in folder.Files.ToList())
                {
                    DeleteFile(file);
                }
            }

            if (folder.Folders.Any())
            {
                foreach (FolderModel fld in folder.Folders.ToList())
                {
                    FolderModel fld_temp = this.Folders
                        .Include(x => x.Folders)
                        .Include(x => x.Files)
                        .FirstOrDefault(x => x.Id == fld.Id);

                    if (fld.Folders.Any())
                    {
                        DeleteFolderDirectory(fld);
                    }
                    DeleteFolder(fld);
                } 
            }
            DeleteFolder(folder);
        }



        // method for seeding img data
        public byte[] ReadFile(string path)
        {
            FileInfo fInfo = new(path);
            long numBytes = fInfo.Length;

            FileStream fStream = new(path, FileMode.Open, FileAccess.Read);

            BinaryReader br = new(fStream);

            byte[] data = br.ReadBytes((int)numBytes);
            return data;
        }
    }
}