﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teknik.Data;

namespace Teknik.Data.Migrations
{
    [DbContext(typeof(TeknikEntities))]
    partial class TeknikEntitiesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview2-35157")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Teknik.Areas.Blog.Models.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId");

                    b.HasKey("BlogId");

                    b.HasIndex("UserId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("Teknik.Areas.Blog.Models.BlogPost", b =>
                {
                    b.Property<int>("BlogPostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Article");

                    b.Property<int>("BlogId");

                    b.Property<DateTime>("DateEdited");

                    b.Property<DateTime>("DatePosted");

                    b.Property<DateTime>("DatePublished");

                    b.Property<bool>("Published");

                    b.Property<bool>("System");

                    b.Property<string>("Title");

                    b.HasKey("BlogPostId");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("Teknik.Areas.Blog.Models.BlogPostComment", b =>
                {
                    b.Property<int>("BlogPostCommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Article");

                    b.Property<int>("BlogPostId");

                    b.Property<DateTime>("DateEdited");

                    b.Property<DateTime>("DatePosted");

                    b.Property<int?>("UserId");

                    b.HasKey("BlogPostCommentId");

                    b.HasIndex("BlogPostId");

                    b.HasIndex("UserId");

                    b.ToTable("BlogPostComments");
                });

            modelBuilder.Entity("Teknik.Areas.Blog.Models.BlogPostTag", b =>
                {
                    b.Property<int>("BlogPostTagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogPostId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("BlogPostTagId");

                    b.HasIndex("BlogPostId");

                    b.ToTable("BlogPostTags");
                });

            modelBuilder.Entity("Teknik.Areas.Contact.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Email");

                    b.Property<string>("Message");

                    b.Property<string>("Name");

                    b.Property<string>("Subject");

                    b.HasKey("ContactId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Teknik.Areas.Paste.Models.Paste", b =>
                {
                    b.Property<int>("PasteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlockSize");

                    b.Property<string>("Content");

                    b.Property<DateTime>("DatePosted");

                    b.Property<DateTime?>("ExpireDate");

                    b.Property<string>("HashedPassword")
                        .HasAnnotation("CaseSensitive", true);

                    b.Property<bool>("Hide");

                    b.Property<string>("IV")
                        .HasAnnotation("CaseSensitive", true);

                    b.Property<string>("Key")
                        .HasAnnotation("CaseSensitive", true);

                    b.Property<int>("KeySize");

                    b.Property<int>("MaxViews");

                    b.Property<string>("Syntax");

                    b.Property<string>("Title");

                    b.Property<string>("Url")
                        .HasAnnotation("CaseSensitive", true);

                    b.Property<int?>("UserId");

                    b.Property<int>("Views");

                    b.HasKey("PasteId");

                    b.HasIndex("UserId");

                    b.ToTable("Pastes");
                });

            modelBuilder.Entity("Teknik.Areas.Podcast.Models.Podcast", b =>
                {
                    b.Property<int>("PodcastId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEdited");

                    b.Property<DateTime>("DatePosted");

                    b.Property<DateTime>("DatePublished");

                    b.Property<string>("Description");

                    b.Property<int>("Episode");

                    b.Property<bool>("Published");

                    b.Property<string>("Title");

                    b.HasKey("PodcastId");

                    b.ToTable("Podcasts");
                });

            modelBuilder.Entity("Teknik.Areas.Podcast.Models.PodcastComment", b =>
                {
                    b.Property<int>("PodcastCommentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Article");

                    b.Property<DateTime>("DateEdited");

                    b.Property<DateTime>("DatePosted");

                    b.Property<int>("PodcastId");

                    b.Property<int>("UserId");

                    b.HasKey("PodcastCommentId");

                    b.HasIndex("PodcastId");

                    b.HasIndex("UserId");

                    b.ToTable("PodcastComments");
                });

            modelBuilder.Entity("Teknik.Areas.Podcast.Models.PodcastFile", b =>
                {
                    b.Property<int>("PodcastFileId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ContentLength");

                    b.Property<string>("ContentType");

                    b.Property<string>("FileName");

                    b.Property<string>("Path");

                    b.Property<int>("PodcastId");

                    b.Property<int>("Size");

                    b.HasKey("PodcastFileId");

                    b.HasIndex("PodcastId");

                    b.ToTable("PodcastFiles");
                });

            modelBuilder.Entity("Teknik.Areas.Podcast.Models.PodcastTag", b =>
                {
                    b.Property<int>("PodcastTagId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("PodcastId");

                    b.HasKey("PodcastTagId");

                    b.HasIndex("PodcastId");

                    b.ToTable("PodcastTags");
                });

            modelBuilder.Entity("Teknik.Areas.Shortener.Models.ShortenedUrl", b =>
                {
                    b.Property<int>("ShortenedUrlId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("OriginalUrl");

                    b.Property<string>("ShortUrl")
                        .HasAnnotation("CaseSensitive", true);

                    b.Property<int?>("UserId");

                    b.Property<int>("Views");

                    b.HasKey("ShortenedUrlId");

                    b.HasIndex("UserId");

                    b.ToTable("ShortenedUrls");
                });

            modelBuilder.Entity("Teknik.Areas.Stats.Models.Takedown", b =>
                {
                    b.Property<int>("TakedownId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionTaken");

                    b.Property<DateTime>("DateActionTaken");

                    b.Property<DateTime>("DateRequested");

                    b.Property<string>("Reason");

                    b.Property<string>("Requester");

                    b.Property<string>("RequesterContact");

                    b.HasKey("TakedownId");

                    b.ToTable("Takedowns");
                });

            modelBuilder.Entity("Teknik.Areas.Stats.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(19, 5)");

                    b.Property<int>("Currency");

                    b.Property<DateTime>("DateSent");

                    b.Property<string>("Reason");

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Teknik.Areas.Upload.Models.Upload", b =>
                {
                    b.Property<int>("UploadId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlockSize");

                    b.Property<long>("ContentLength");

                    b.Property<string>("ContentType");

                    b.Property<DateTime>("DateUploaded");

                    b.Property<string>("DeleteKey")
                        .HasAnnotation("CaseSensitive", true);

                    b.Property<int>("Downloads");

                    b.Property<string>("FileName")
                        .HasAnnotation("CaseSensitive", true);

                    b.Property<string>("IV")
                        .HasAnnotation("CaseSensitive", true);

                    b.Property<string>("Key")
                        .HasAnnotation("CaseSensitive", true);

                    b.Property<int>("KeySize");

                    b.Property<int?>("Takedown_TakedownId");

                    b.Property<string>("Url")
                        .HasAnnotation("CaseSensitive", true);

                    b.Property<int?>("UserId");

                    b.HasKey("UploadId");

                    b.HasIndex("Takedown_TakedownId");

                    b.HasIndex("UserId");

                    b.ToTable("Uploads");
                });

            modelBuilder.Entity("Teknik.Areas.Users.Models.InviteCode", b =>
                {
                    b.Property<int>("InviteCodeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int?>("ClaimedUserId");

                    b.Property<string>("Code")
                        .HasAnnotation("CaseSensitive", true);

                    b.Property<int?>("OwnerId");

                    b.HasKey("InviteCodeId");

                    b.HasIndex("ClaimedUserId")
                        .IsUnique()
                        .HasFilter("[ClaimedUserId] IS NOT NULL");

                    b.HasIndex("OwnerId");

                    b.ToTable("InviteCodes");
                });

            modelBuilder.Entity("Teknik.Areas.Users.Models.LoginInfo", b =>
                {
                    b.Property<int>("LoginInfoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.Property<int>("UserId");

                    b.HasKey("LoginInfoId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Teknik.Areas.Users.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Teknik.Areas.Vault.Models.Vault", b =>
                {
                    b.Property<int>("VaultId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateEdited");

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.Property<int?>("UserId");

                    b.Property<int>("Views");

                    b.HasKey("VaultId");

                    b.HasIndex("UserId");

                    b.ToTable("Vaults");
                });

            modelBuilder.Entity("Teknik.Areas.Vault.Models.VaultItem", b =>
                {
                    b.Property<int>("VaultItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.Property<int>("VaultId");

                    b.HasKey("VaultItemId");

                    b.HasIndex("VaultId");

                    b.ToTable("VaultItems");

                    b.HasDiscriminator<string>("Discriminator").HasValue("VaultItem");
                });

            modelBuilder.Entity("Teknik.Areas.Vault.Models.PasteVaultItem", b =>
                {
                    b.HasBaseType("Teknik.Areas.Vault.Models.VaultItem");

                    b.Property<int>("PasteId");

                    b.HasIndex("PasteId");

                    b.HasDiscriminator().HasValue("PasteVaultItem");
                });

            modelBuilder.Entity("Teknik.Areas.Vault.Models.UploadVaultItem", b =>
                {
                    b.HasBaseType("Teknik.Areas.Vault.Models.VaultItem");

                    b.Property<int>("UploadId");

                    b.HasIndex("UploadId");

                    b.HasDiscriminator().HasValue("UploadVaultItem");
                });

            modelBuilder.Entity("Teknik.Areas.Blog.Models.Blog", b =>
                {
                    b.HasOne("Teknik.Areas.Users.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teknik.Areas.Blog.Models.BlogPost", b =>
                {
                    b.HasOne("Teknik.Areas.Blog.Models.Blog", "Blog")
                        .WithMany("BlogPosts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teknik.Areas.Blog.Models.BlogPostComment", b =>
                {
                    b.HasOne("Teknik.Areas.Blog.Models.BlogPost", "BlogPost")
                        .WithMany("Comments")
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Teknik.Areas.Users.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Teknik.Areas.Blog.Models.BlogPostTag", b =>
                {
                    b.HasOne("Teknik.Areas.Blog.Models.BlogPost", "BlogPost")
                        .WithMany("Tags")
                        .HasForeignKey("BlogPostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teknik.Areas.Paste.Models.Paste", b =>
                {
                    b.HasOne("Teknik.Areas.Users.Models.User", "User")
                        .WithMany("Pastes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Teknik.Areas.Podcast.Models.PodcastComment", b =>
                {
                    b.HasOne("Teknik.Areas.Podcast.Models.Podcast", "Podcast")
                        .WithMany("Comments")
                        .HasForeignKey("PodcastId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Teknik.Areas.Users.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teknik.Areas.Podcast.Models.PodcastFile", b =>
                {
                    b.HasOne("Teknik.Areas.Podcast.Models.Podcast", "Podcast")
                        .WithMany("Files")
                        .HasForeignKey("PodcastId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teknik.Areas.Podcast.Models.PodcastTag", b =>
                {
                    b.HasOne("Teknik.Areas.Podcast.Models.Podcast", "Podcast")
                        .WithMany("Tags")
                        .HasForeignKey("PodcastId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teknik.Areas.Shortener.Models.ShortenedUrl", b =>
                {
                    b.HasOne("Teknik.Areas.Users.Models.User", "User")
                        .WithMany("ShortenedUrls")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Teknik.Areas.Upload.Models.Upload", b =>
                {
                    b.HasOne("Teknik.Areas.Stats.Models.Takedown")
                        .WithMany("Attachments")
                        .HasForeignKey("Takedown_TakedownId");

                    b.HasOne("Teknik.Areas.Users.Models.User", "User")
                        .WithMany("Uploads")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Teknik.Areas.Users.Models.InviteCode", b =>
                {
                    b.HasOne("Teknik.Areas.Users.Models.User", "ClaimedUser")
                        .WithOne("ClaimedInviteCode")
                        .HasForeignKey("Teknik.Areas.Users.Models.InviteCode", "ClaimedUserId");

                    b.HasOne("Teknik.Areas.Users.Models.User", "Owner")
                        .WithMany("OwnedInviteCodes")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Teknik.Areas.Users.Models.LoginInfo", b =>
                {
                    b.HasOne("Teknik.Areas.Users.Models.User", "User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teknik.Areas.Users.Models.User", b =>
                {
                    b.OwnsOne("Teknik.Areas.Users.Models.BlogSettings", "BlogSettings", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Description")
                                .HasColumnName("Description");

                            b1.Property<string>("Title")
                                .HasColumnName("Title");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.HasOne("Teknik.Areas.Users.Models.User")
                                .WithOne("BlogSettings")
                                .HasForeignKey("Teknik.Areas.Users.Models.BlogSettings", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Teknik.Areas.Users.Models.UploadSettings", "UploadSettings", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<bool>("Encrypt")
                                .HasColumnName("Encrypt");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.HasOne("Teknik.Areas.Users.Models.User")
                                .WithOne("UploadSettings")
                                .HasForeignKey("Teknik.Areas.Users.Models.UploadSettings", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Teknik.Areas.Users.Models.UserSettings", "UserSettings", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("About")
                                .HasColumnName("About");

                            b1.Property<string>("Quote")
                                .HasColumnName("Quote");

                            b1.Property<string>("Website")
                                .HasColumnName("Website");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.HasOne("Teknik.Areas.Users.Models.User")
                                .WithOne("UserSettings")
                                .HasForeignKey("Teknik.Areas.Users.Models.UserSettings", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Teknik.Areas.Vault.Models.Vault", b =>
                {
                    b.HasOne("Teknik.Areas.Users.Models.User", "User")
                        .WithMany("Vaults")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Teknik.Areas.Vault.Models.VaultItem", b =>
                {
                    b.HasOne("Teknik.Areas.Vault.Models.Vault", "Vault")
                        .WithMany("VaultItems")
                        .HasForeignKey("VaultId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teknik.Areas.Vault.Models.PasteVaultItem", b =>
                {
                    b.HasOne("Teknik.Areas.Paste.Models.Paste", "Paste")
                        .WithMany("PasteVaultItems")
                        .HasForeignKey("PasteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teknik.Areas.Vault.Models.UploadVaultItem", b =>
                {
                    b.HasOne("Teknik.Areas.Upload.Models.Upload", "Upload")
                        .WithMany("UploadVaultItems")
                        .HasForeignKey("UploadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
