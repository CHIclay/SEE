﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SEEEntities : DbContext
    {
        public SEEEntities()
            : base("name=SEEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActPicture> ActPicture { get; set; }
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Album_Comment> Album_Comment { get; set; }
        public virtual DbSet<Album_Point> Album_Point { get; set; }
        public virtual DbSet<Album_Save> Album_Save { get; set; }
        public virtual DbSet<Attention> Attention { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<News_Comment> News_Comment { get; set; }
        public virtual DbSet<Pic_Comment> Pic_Comment { get; set; }
        public virtual DbSet<Pic_Comment_Comment> Pic_Comment_Comment { get; set; }
        public virtual DbSet<Pic_Point> Pic_Point { get; set; }
        public virtual DbSet<PicInActivity> PicInActivity { get; set; }
        public virtual DbSet<Picture> Picture { get; set; }
        public virtual DbSet<Picture_In_Album> Picture_In_Album { get; set; }
        public virtual DbSet<Picture_Type> Picture_Type { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
    }
}
