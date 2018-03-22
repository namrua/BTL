namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Dbcontext : DbContext
    {
        public Dbcontext()
            : base("name=Dbcontext")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<ContentTag> ContentTags { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<Content>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<ContentTag>()
                .Property(e => e.TagID)
                .IsUnicode(false);

            modelBuilder.Entity<FeedBack>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<Footer>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.PromotionPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<ProductCategory>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<Slide>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<Slide>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsFixedLength();

            modelBuilder.Entity<Contact>()
                .Property(e => e.Status)
                .IsFixedLength();
        }
    }
}