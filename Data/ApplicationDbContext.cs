using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RealEstate.Models;

namespace RealEstate.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(150000);
            
        }

        public virtual DbSet<AuthGroup> AuthGroups { get; set; } = null!;
        public virtual DbSet<AuthGroupPermission> AuthGroupPermissions { get; set; } = null!;
        public virtual DbSet<AuthPermission> AuthPermissions { get; set; } = null!;
        public virtual DbSet<AuthUser> AuthUsers { get; set; } = null!;
        public virtual DbSet<AuthUserGroup> AuthUserGroups { get; set; } = null!;
        public virtual DbSet<AuthUserUserPermission> AuthUserUserPermissions { get; set; } = null!;
        public virtual DbSet<Brokeragephonenumber> Brokeragephonenumbers { get; set; } = null!;
        public virtual DbSet<DjangoAdminLog> DjangoAdminLogs { get; set; } = null!;
        public virtual DbSet<DjangoContentType> DjangoContentTypes { get; set; } = null!;
        public virtual DbSet<DjangoMigration> DjangoMigrations { get; set; } = null!;
        public virtual DbSet<DjangoQOrmq> DjangoQOrmqs { get; set; } = null!;
        public virtual DbSet<DjangoQSchedule> DjangoQSchedules { get; set; } = null!;
        public virtual DbSet<DjangoQTask> DjangoQTasks { get; set; } = null!;
        public virtual DbSet<DjangoSession> DjangoSessions { get; set; } = null!;
        public virtual DbSet<DjangoSite> DjangoSites { get; set; } = null!;
        public virtual DbSet<Home> Homes { get; set; } = null!;
        public virtual DbSet<HomeInterested> HomeInteresteds { get; set; } = null!;
        public virtual DbSet<Imagelink> Imagelinks { get; set; } = null!;
        public virtual DbSet<Landtype> Landtypes { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Realestatebroker> Realestatebrokers { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Scraperconfig> Scraperconfigs { get; set; } = null!;
        public virtual DbSet<Searchlocation> Searchlocations { get; set; } = null!;
        public virtual DbSet<Useragentname> Useragentnames { get; set; } = null!;
        public virtual DbSet<Userprofileinfo> Userprofileinfos { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseLowerCaseNamingConvention();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Home>()
                .HasGeneratedTsVectorColumn(
                    p => p.SearchVector,
                    "english", 
                    p => new { p.GeneralizedAddress, p.MlsNumber, 
                        p.Brokerage, p.Type, p.SubType, p.YearBuilt, p.NeighborHood,
                        p.Description, p.FeaturesAndFinishes, p.GenSlug
                    })
                .HasIndex(p => p.SearchVector)
                .HasMethod("GIN"); 
            modelBuilder.Entity<Location>()
                .HasGeneratedTsVectorColumn(
                    p => p.SearchVector,
                    "english", 
                    p => new { p.City, p.ExactAddress, 
                        p.PostalCode
                    })
                .HasIndex(p => p.SearchVector)
                .HasMethod("GIN"); 
            
            modelBuilder.Entity<Realestatebroker>()
                .HasGeneratedTsVectorColumn(
                    p => p.SearchVector,
                    "english", 
                    p => new { p.Name, p.Brokerage
                    })
                .HasIndex(p => p.SearchVector)
                .HasMethod("GIN"); 
            
            modelBuilder.Entity<AuthGroup>(entity =>
            {
                entity.ToTable("auth_group");

                entity.HasIndex(e => e.Name, "auth_group_name_a6ea08ec_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.HasIndex(e => e.Name, "auth_group_name_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<AuthGroupPermission>(entity =>
            {
                entity.ToTable("auth_group_permissions");

                entity.HasIndex(e => e.GroupId, "auth_group_permissions_group_id_b120cbf9");

                entity.HasIndex(e => new { e.GroupId, e.PermissionId }, "auth_group_permissions_group_id_permission_id_0cd325b0_uniq")
                    .IsUnique();

                entity.HasIndex(e => e.PermissionId, "auth_group_permissions_permission_id_84c5c92e");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AuthGroupPermissions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_group_permissions_group_id_b120cbf9_fk_auth_group_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AuthGroupPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_group_permissio_permission_id_84c5c92e_fk_auth_perm");
            });

            modelBuilder.Entity<AuthPermission>(entity =>
            {
                entity.ToTable("auth_permission");

                entity.HasIndex(e => e.ContentTypeId, "auth_permission_content_type_id_2f476e4b");

                entity.HasIndex(e => new { e.ContentTypeId, e.Codename }, "auth_permission_content_type_id_codename_01ab375a_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codename)
                    .HasMaxLength(100)
                    .HasColumnName("codename");

                entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.AuthPermissions)
                    .HasForeignKey(d => d.ContentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_permission_content_type_id_2f476e4b_fk_django_co");
            });

            modelBuilder.Entity<AuthUser>(entity =>
            {
                entity.ToTable("auth_user");

                entity.HasIndex(e => e.Username, "auth_user_username_6821ab7c_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.HasIndex(e => e.Username, "auth_user_username_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateJoined).HasColumnName("date_joined");

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(150)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsStaff).HasColumnName("is_staff");

                entity.Property(e => e.IsSuperuser).HasColumnName("is_superuser");

                entity.Property(e => e.LastLogin).HasColumnName("last_login");

                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<AuthUserGroup>(entity =>
            {
                entity.ToTable("auth_user_groups");

                entity.HasIndex(e => e.GroupId, "auth_user_groups_group_id_97559544");

                entity.HasIndex(e => e.UserId, "auth_user_groups_user_id_6a12ed8b");

                entity.HasIndex(e => new { e.UserId, e.GroupId }, "auth_user_groups_user_id_group_id_94350c0c_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AuthUserGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_user_groups_group_id_97559544_fk_auth_group_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuthUserGroups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_user_groups_user_id_6a12ed8b_fk_auth_user_id");
            });

            modelBuilder.Entity<AuthUserUserPermission>(entity =>
            {
                entity.ToTable("auth_user_user_permissions");

                entity.HasIndex(e => e.PermissionId, "auth_user_user_permissions_permission_id_1fbb5f2c");

                entity.HasIndex(e => e.UserId, "auth_user_user_permissions_user_id_a95ead1b");

                entity.HasIndex(e => new { e.UserId, e.PermissionId }, "auth_user_user_permissions_user_id_permission_id_14a6b632_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.AuthUserUserPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_user_user_permi_permission_id_1fbb5f2c_fk_auth_perm");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AuthUserUserPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("auth_user_user_permissions_user_id_a95ead1b_fk_auth_user_id");
            });

            modelBuilder.Entity<Brokeragephonenumber>(entity =>
            {
                entity.ToTable("brokeragephonenumber");

                entity.HasIndex(e => e.RealEstateBrokerFkId, "mainapp_brokeragephonenumber_real_estate_broker_fk_id_fd45cbee");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mainapp_brokeragephonenumber_id_seq'::regclass)");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(25)
                    .HasColumnName("phone_number");

                entity.Property(e => e.RealEstateBrokerFkId).HasColumnName("real_estate_broker_fk_id");

                entity.HasOne(d => d.RealEstateBrokerFk)
                    .WithMany(p => p.Brokeragephonenumbers)
                    .HasForeignKey(d => d.RealEstateBrokerFkId)
                    .HasConstraintName("mainapp_brokeragepho_real_estate_broker_f_fd45cbee_fk_mainapp_r");
            });

            modelBuilder.Entity<DjangoAdminLog>(entity =>
            {
                entity.ToTable("django_admin_log");

                entity.HasIndex(e => e.ContentTypeId, "django_admin_log_content_type_id_c4bce8eb");

                entity.HasIndex(e => e.UserId, "django_admin_log_user_id_c564eba6");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionFlag).HasColumnName("action_flag");

                entity.Property(e => e.ActionTime).HasColumnName("action_time");

                entity.Property(e => e.ChangeMessage).HasColumnName("change_message");

                entity.Property(e => e.ContentTypeId).HasColumnName("content_type_id");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.ObjectRepr)
                    .HasMaxLength(200)
                    .HasColumnName("object_repr");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.DjangoAdminLogs)
                    .HasForeignKey(d => d.ContentTypeId)
                    .HasConstraintName("django_admin_log_content_type_id_c4bce8eb_fk_django_co");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DjangoAdminLogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("django_admin_log_user_id_c564eba6_fk_auth_user_id");
            });

            modelBuilder.Entity<DjangoContentType>(entity =>
            {
                entity.ToTable("django_content_type");

                entity.HasIndex(e => new { e.AppLabel, e.Model }, "django_content_type_app_label_model_76bd3d3b_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AppLabel)
                    .HasMaxLength(100)
                    .HasColumnName("app_label");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .HasColumnName("model");
            });

            modelBuilder.Entity<DjangoMigration>(entity =>
            {
                entity.ToTable("django_migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.App)
                    .HasMaxLength(255)
                    .HasColumnName("app");

                entity.Property(e => e.Applied).HasColumnName("applied");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<DjangoQOrmq>(entity =>
            {
                entity.ToTable("django_q_ormq");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Key)
                    .HasMaxLength(100)
                    .HasColumnName("key");

                entity.Property(e => e.Lock).HasColumnName("lock");

                entity.Property(e => e.Payload).HasColumnName("payload");
            });

            modelBuilder.Entity<DjangoQSchedule>(entity =>
            {
                entity.ToTable("django_q_schedule");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Args).HasColumnName("args");

                entity.Property(e => e.Cluster)
                    .HasMaxLength(100)
                    .HasColumnName("cluster");

                entity.Property(e => e.Cron)
                    .HasMaxLength(100)
                    .HasColumnName("cron");

                entity.Property(e => e.Func)
                    .HasMaxLength(256)
                    .HasColumnName("func");

                entity.Property(e => e.Hook)
                    .HasMaxLength(256)
                    .HasColumnName("hook");

                entity.Property(e => e.Kwargs).HasColumnName("kwargs");

                entity.Property(e => e.Minutes).HasColumnName("minutes");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.NextRun).HasColumnName("next_run");

                entity.Property(e => e.Repeats).HasColumnName("repeats");

                entity.Property(e => e.ScheduleType)
                    .HasMaxLength(1)
                    .HasColumnName("schedule_type");

                entity.Property(e => e.Task)
                    .HasMaxLength(100)
                    .HasColumnName("task");
            });

            modelBuilder.Entity<DjangoQTask>(entity =>
            {
                entity.ToTable("django_q_task");

                entity.HasIndex(e => e.Id, "django_q_task_id_32882367_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .HasColumnName("id");

                entity.Property(e => e.Args).HasColumnName("args");

                entity.Property(e => e.AttemptCount).HasColumnName("attempt_count");

                entity.Property(e => e.Func)
                    .HasMaxLength(256)
                    .HasColumnName("func");

                entity.Property(e => e.Group)
                    .HasMaxLength(100)
                    .HasColumnName("group");

                entity.Property(e => e.Hook)
                    .HasMaxLength(256)
                    .HasColumnName("hook");

                entity.Property(e => e.Kwargs).HasColumnName("kwargs");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.Property(e => e.Started).HasColumnName("started");

                entity.Property(e => e.Stopped).HasColumnName("stopped");

                entity.Property(e => e.Success).HasColumnName("success");
            });

            modelBuilder.Entity<DjangoSession>(entity =>
            {
                entity.HasKey(e => e.SessionKey)
                    .HasName("django_session_pkey");

                entity.ToTable("django_session");

                entity.HasIndex(e => e.ExpireDate, "django_session_expire_date_a5c62663");

                entity.HasIndex(e => e.SessionKey, "django_session_session_key_c0390e0f_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.SessionKey)
                    .HasMaxLength(40)
                    .HasColumnName("session_key");

                entity.Property(e => e.ExpireDate).HasColumnName("expire_date");

                entity.Property(e => e.SessionData).HasColumnName("session_data");
            });

            modelBuilder.Entity<DjangoSite>(entity =>
            {
                entity.ToTable("django_site");

                entity.HasIndex(e => e.Domain, "django_site_domain_a2e37b91_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.HasIndex(e => e.Domain, "django_site_domain_a2e37b91_uniq")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Domain)
                    .HasMaxLength(100)
                    .HasColumnName("domain");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.ToTable("home");

                entity.HasIndex(e => e.AddressFkId, "mainapp_home_address_fk_id_key")
                    .IsUnique();

                entity.HasIndex(e => e.BathRooms, "mainapp_home_bath_rooms_137edddd");

                entity.HasIndex(e => e.BedRooms, "mainapp_home_bed_rooms_e1dd4d2b");

                entity.HasIndex(e => e.CreatedAt, "mainapp_home_created_at_274498cc");

                entity.HasIndex(e => e.GeneralizedAddress, "mainapp_home_generalized_address_3bde2872_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.HasIndex(e => e.GeneralizedAddress, "mainapp_home_generalized_address_key")
                    .IsUnique();

                entity.HasIndex(e => e.LinkUrl, "mainapp_home_link_url_a7c2ffa4");

                entity.HasIndex(e => e.LinkUrl, "mainapp_home_link_url_a7c2ffa4_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.HasIndex(e => e.MlsNumber, "mainapp_home_mls_number_695b3ba1");

                entity.HasIndex(e => e.MlsNumber, "mainapp_home_mls_number_695b3ba1_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.HasIndex(e => e.Price, "mainapp_home_price_94cbb17b");

                entity.HasIndex(e => e.RealEstateBrokerFkId, "mainapp_home_real_estate_broker_fk_id_cd1e8434");

                entity.HasIndex(e => e.RentPrice, "mainapp_home_rent_price_ee9cc280");

                entity.HasIndex(e => e.UpdatedAt, "mainapp_home_updated_at_2c8b37bc");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mainapp_home_id_seq'::regclass)");

                entity.Property(e => e.AddressFkId).HasColumnName("address_fk_id");

                entity.Property(e => e.Basement)
                    .HasMaxLength(70)
                    .HasColumnName("basement");

                entity.Property(e => e.BathRooms).HasColumnName("bath_rooms");

                entity.Property(e => e.BedRooms).HasColumnName("bed_rooms");

                entity.Property(e => e.Brokerage)
                    .HasMaxLength(70)
                    .HasColumnName("brokerage");

                entity.Property(e => e.BuilderName)
                    .HasMaxLength(50)
                    .HasColumnName("builder_name");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.FeaturesAndFinishes).HasColumnName("features_and_finishes");

                entity.Property(e => e.FromRemax).HasColumnName("from_remax");

                entity.Property(e => e.GenSlug)
                    .HasMaxLength(120)
                    .HasColumnName("gen_slug");

                entity.Property(e => e.GeneralizedAddress)
                    .HasMaxLength(130)
                    .HasColumnName("generalized_address");

                entity.Property(e => e.HtmlPage).HasColumnName("html_page");

                entity.Property(e => e.LinkUrl)
                    .HasMaxLength(190)
                    .HasColumnName("link_url");

                entity.Property(e => e.MlsNumber)
                    .HasMaxLength(30)
                    .HasColumnName("mls_number");

                entity.Property(e => e.NeighborHood)
                    .HasMaxLength(50)
                    .HasColumnName("neighbor_hood");

                entity.Property(e => e.NewConstruction).HasColumnName("new_construction");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.RealEstateBrokerFkId).HasColumnName("real_estate_broker_fk_id");

                entity.Property(e => e.RentPrice).HasColumnName("rent_price");

                entity.Property(e => e.Rentable).HasColumnName("rentable");

                entity.Property(e => e.SubType)
                    .HasMaxLength(30)
                    .HasColumnName("sub_type");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .HasColumnName("type");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.YearBuilt)
                    .HasMaxLength(8)
                    .HasColumnName("year_built");

                entity.HasOne(d => d.AddressFk)
                    .WithOne(p => p.Home)
                    .HasForeignKey<Home>(d => d.AddressFkId)
                    .HasConstraintName("mainapp_home_address_fk_id_aa9741e6_fk_mainapp_location_id");

                entity.HasOne(d => d.RealEstateBrokerFk)
                    .WithMany(p => p.Homes)
                    .HasForeignKey(d => d.RealEstateBrokerFkId)
                    .HasConstraintName("mainapp_home_real_estate_broker_f_cd1e8434_fk_mainapp_r");
            });

            modelBuilder.Entity<HomeInterested>(entity =>
            {
                entity.ToTable("home_interested");

                entity.HasIndex(e => e.HomeId, "mainapp_home_interested_home_id_263ffd84");

                entity.HasIndex(e => new { e.HomeId, e.UserId }, "mainapp_home_interested_home_id_user_id_93aac0c5_uniq")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "mainapp_home_interested_user_id_32383c2b");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mainapp_home_interested_id_seq'::regclass)");

                entity.Property(e => e.HomeId).HasColumnName("home_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.HomeInteresteds)
                    .HasForeignKey(d => d.HomeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mainapp_home_interested_home_id_263ffd84_fk_mainapp_home_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.HomeInteresteds)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mainapp_home_interested_user_id_32383c2b_fk_auth_user_id");
            });

            modelBuilder.Entity<Imagelink>(entity =>
            {
                entity.ToTable("imagelink");

                entity.HasIndex(e => e.HomeFkId, "mainapp_homeimagelink_home_fk_id_467c2a69");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mainapp_homeimagelink_id_seq'::regclass)");

                entity.Property(e => e.HomeFkId).HasColumnName("home_fk_id");

                entity.Property(e => e.Link)
                    .HasMaxLength(200)
                    .HasColumnName("link");

                entity.HasOne(d => d.HomeFk)
                    .WithMany(p => p.Imagelinks)
                    .HasForeignKey(d => d.HomeFkId)
                    .HasConstraintName("mainapp_homeimagelink_home_fk_id_467c2a69_fk_mainapp_home_id");
            });

            modelBuilder.Entity<Landtype>(entity =>
            {
                entity.ToTable("landtype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mainapp_landtype_id_seq'::regclass)");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.HasIndex(e => e.City, "mainapp_location_city_36967550");

                entity.HasIndex(e => e.City, "mainapp_location_city_36967550_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.HasIndex(e => e.HouseNumber, "mainapp_location_house_number_881c76ce");

                entity.HasIndex(e => e.HouseNumber, "mainapp_location_house_number_881c76ce_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.HasIndex(e => e.Lat, "mainapp_location_lat_2905578d");

                entity.HasIndex(e => e.Long, "mainapp_location_long_cfc4fc6a");

                entity.HasIndex(e => e.PostalCode, "mainapp_location_postal_code_2d4d36cd");

                entity.HasIndex(e => e.PostalCode, "mainapp_location_postal_code_2d4d36cd_like")
                    .HasOperators(new[] { "varchar_pattern_ops" });

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mainapp_location_id_seq'::regclass)");

                entity.Property(e => e.City)
                    .HasMaxLength(35)
                    .HasColumnName("city");

                entity.Property(e => e.ExactAddress)
                    .HasMaxLength(150)
                    .HasColumnName("exact_address");

                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(35)
                    .HasColumnName("house_number");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Long).HasColumnName("long");

                entity.Property(e => e.MapBoxResult).HasColumnName("map_box_result");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(9)
                    .HasColumnName("postal_code");
            });

            modelBuilder.Entity<Realestatebroker>(entity =>
            {
                entity.ToTable("realestatebroker");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mainapp_realestatebroker_id_seq'::regclass)");

                entity.Property(e => e.Brokerage)
                    .HasMaxLength(65)
                    .HasColumnName("brokerage");

                entity.Property(e => e.BrokerageWebsite).HasColumnName("brokerageWebsite");

                entity.Property(e => e.Name)
                    .HasMaxLength(65)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");

                entity.HasIndex(e => e.HomeFkId, "mainapp_room_home_fk_id_20c7a123");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mainapp_room_id_seq'::regclass)");

                entity.Property(e => e.HomeFkId).HasColumnName("home_fk_id");

                entity.Property(e => e.Location)
                    .HasMaxLength(125)
                    .HasColumnName("location");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name");

                entity.Property(e => e.RoomSize)
                    .HasMaxLength(20)
                    .HasColumnName("room_size");

                entity.HasOne(d => d.HomeFk)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HomeFkId)
                    .HasConstraintName("mainapp_room_home_fk_id_20c7a123_fk_mainapp_home_id");
            });

            modelBuilder.Entity<Scraperconfig>(entity =>
            {
                entity.ToTable("scraperconfig");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mainapp_scrapingconfig_id_seq'::regclass)");

                entity.Property(e => e.BaseDomain).HasColumnName("base_domain");

                entity.Property(e => e.ScrapConfigName).HasColumnName("scrap_config_name");
            });

            modelBuilder.Entity<Searchlocation>(entity =>
            {
                entity.ToTable("searchlocation");

                entity.HasIndex(e => e.ScrapingConfigFkId, "mainapp_scrapingsearchlocation_scraping_config_fk_id_6f277334");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mainapp_scrapingsearchlocation_id_seq'::regclass)");

                entity.Property(e => e.LocationName).HasColumnName("location_name");

                entity.Property(e => e.ScrapingConfigFkId).HasColumnName("scraping_config_fk_id");

                entity.HasOne(d => d.ScrapingConfigFk)
                    .WithMany(p => p.Searchlocations)
                    .HasForeignKey(d => d.ScrapingConfigFkId)
                    .HasConstraintName("mainapp_scrapingsear_scraping_config_fk_i_6f277334_fk_mainapp_s");
            });

            modelBuilder.Entity<Useragentname>(entity =>
            {
                entity.ToTable("useragentname");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mainapp_useragentname_id_seq'::regclass)");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Userprofileinfo>(entity =>
            {
                entity.ToTable("userprofileinfo");

                entity.HasIndex(e => e.UserFkId, "mainapp_userprofileinfo_user_fk_id_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mainapp_userprofileinfo_id_seq'::regclass)");

                entity.Property(e => e.UserFkId).HasColumnName("user_fk_id");

                entity.HasOne(d => d.UserFk)
                    .WithOne(p => p.Userprofileinfo)
                    .HasForeignKey<Userprofileinfo>(d => d.UserFkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mainapp_userprofileinfo_user_fk_id_9fe7715b_fk_auth_user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
