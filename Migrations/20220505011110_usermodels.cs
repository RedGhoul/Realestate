using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RealEstate.Migrations
{
    public partial class usermodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });
            // try
            // {
            //     migrationBuilder.CreateTable(
            //         name: "landtype",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('mainapp_landtype_id_seq'::regclass)"),
            //             name = table.Column<string>(type: "text", nullable: true)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_landtype", x => x.id);
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "location",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('mainapp_location_id_seq'::regclass)"),
            //             exact_address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
            //             city = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: true),
            //             house_number = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: true),
            //             lat = table.Column<double>(type: "double precision", nullable: true),
            //             @long = table.Column<double>(name: "long", type: "double precision", nullable: true),
            //             postal_code = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: true),
            //             map_box_result = table.Column<string>(type: "text", nullable: true)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_location", x => x.id);
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "realestatebroker",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('mainapp_realestatebroker_id_seq'::regclass)"),
            //             name = table.Column<string>(type: "character varying(65)", maxLength: 65, nullable: false),
            //             brokerage = table.Column<string>(type: "character varying(65)", maxLength: 65, nullable: false),
            //             brokerageWebsite = table.Column<string>(type: "text", nullable: false)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_realestatebroker", x => x.id);
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "scraperconfig",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('mainapp_scrapingconfig_id_seq'::regclass)"),
            //             base_domain = table.Column<string>(type: "text", nullable: false),
            //             scrap_config_name = table.Column<string>(type: "text", nullable: false)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_scraperconfig", x => x.id);
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "useragentname",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('mainapp_useragentname_id_seq'::regclass)"),
            //             name = table.Column<string>(type: "text", nullable: true)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_useragentname", x => x.id);
            //         });
            //     
            //      migrationBuilder.CreateTable(
            //         name: "auth_user_groups",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false)
            //                 .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //             user_id = table.Column<int>(type: "integer", nullable: false),
            //             group_id = table.Column<int>(type: "integer", nullable: false)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_auth_user_groups", x => x.id);
            //             table.ForeignKey(
            //                 name: "auth_user_groups_group_id_97559544_fk_auth_group_id",
            //                 column: x => x.group_id,
            //                 principalTable: "auth_group",
            //                 principalColumn: "id");
            //             table.ForeignKey(
            //                 name: "auth_user_groups_user_id_6a12ed8b_fk_auth_user_id",
            //                 column: x => x.user_id,
            //                 principalTable: "auth_user",
            //                 principalColumn: "id");
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "userprofileinfo",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('mainapp_userprofileinfo_id_seq'::regclass)"),
            //             user_fk_id = table.Column<int>(type: "integer", nullable: false)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_userprofileinfo", x => x.id);
            //             table.ForeignKey(
            //                 name: "mainapp_userprofileinfo_user_fk_id_9fe7715b_fk_auth_user_id",
            //                 column: x => x.user_fk_id,
            //                 principalTable: "auth_user",
            //                 principalColumn: "id");
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "auth_permission",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false)
            //                 .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //             name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
            //             content_type_id = table.Column<int>(type: "integer", nullable: false),
            //             codename = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_auth_permission", x => x.id);
            //             table.ForeignKey(
            //                 name: "auth_permission_content_type_id_2f476e4b_fk_django_co",
            //                 column: x => x.content_type_id,
            //                 principalTable: "django_content_type",
            //                 principalColumn: "id");
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "django_admin_log",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false)
            //                 .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //             action_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //             object_id = table.Column<string>(type: "text", nullable: true),
            //             object_repr = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
            //             action_flag = table.Column<short>(type: "smallint", nullable: false),
            //             change_message = table.Column<string>(type: "text", nullable: false),
            //             content_type_id = table.Column<int>(type: "integer", nullable: true),
            //             user_id = table.Column<int>(type: "integer", nullable: false)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_django_admin_log", x => x.id);
            //             table.ForeignKey(
            //                 name: "django_admin_log_content_type_id_c4bce8eb_fk_django_co",
            //                 column: x => x.content_type_id,
            //                 principalTable: "django_content_type",
            //                 principalColumn: "id");
            //             table.ForeignKey(
            //                 name: "django_admin_log_user_id_c564eba6_fk_auth_user_id",
            //                 column: x => x.user_id,
            //                 principalTable: "auth_user",
            //                 principalColumn: "id");
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "brokeragephonenumber",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('mainapp_brokeragephonenumber_id_seq'::regclass)"),
            //             phone_number = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
            //             real_estate_broker_fk_id = table.Column<int>(type: "integer", nullable: true)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_brokeragephonenumber", x => x.id);
            //             table.ForeignKey(
            //                 name: "mainapp_brokeragepho_real_estate_broker_f_fd45cbee_fk_mainapp_r",
            //                 column: x => x.real_estate_broker_fk_id,
            //                 principalTable: "realestatebroker",
            //                 principalColumn: "id");
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "home",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('mainapp_home_id_seq'::regclass)"),
            //             generalized_address = table.Column<string>(type: "character varying(130)", maxLength: 130, nullable: false),
            //             mls_number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
            //             bed_rooms = table.Column<double>(type: "double precision", nullable: false),
            //             bath_rooms = table.Column<double>(type: "double precision", nullable: false),
            //             price = table.Column<long>(type: "bigint", nullable: false),
            //             brokerage = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
            //             type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
            //             sub_type = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
            //             year_built = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
            //             neighbor_hood = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            //             basement = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
            //             description = table.Column<string>(type: "text", nullable: true),
            //             link_url = table.Column<string>(type: "character varying(190)", maxLength: 190, nullable: false),
            //             new_construction = table.Column<bool>(type: "boolean", nullable: false),
            //             from_remax = table.Column<bool>(type: "boolean", nullable: false),
            //             rentable = table.Column<bool>(type: "boolean", nullable: false),
            //             builder_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
            //             features_and_finishes = table.Column<string>(type: "text", nullable: true),
            //             rent_price = table.Column<long>(type: "bigint", nullable: true),
            //             created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //             updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //             address_fk_id = table.Column<int>(type: "integer", nullable: true),
            //             real_estate_broker_fk_id = table.Column<int>(type: "integer", nullable: true),
            //             gen_slug = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true),
            //             html_page = table.Column<string>(type: "text", nullable: true)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_home", x => x.id);
            //             table.ForeignKey(
            //                 name: "mainapp_home_address_fk_id_aa9741e6_fk_mainapp_location_id",
            //                 column: x => x.address_fk_id,
            //                 principalTable: "location",
            //                 principalColumn: "id");
            //             table.ForeignKey(
            //                 name: "mainapp_home_real_estate_broker_f_cd1e8434_fk_mainapp_r",
            //                 column: x => x.real_estate_broker_fk_id,
            //                 principalTable: "realestatebroker",
            //                 principalColumn: "id");
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "searchlocation",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('mainapp_scrapingsearchlocation_id_seq'::regclass)"),
            //             location_name = table.Column<string>(type: "text", nullable: true),
            //             scraping_config_fk_id = table.Column<int>(type: "integer", nullable: true)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_searchlocation", x => x.id);
            //             table.ForeignKey(
            //                 name: "mainapp_scrapingsear_scraping_config_fk_i_6f277334_fk_mainapp_s",
            //                 column: x => x.scraping_config_fk_id,
            //                 principalTable: "scraperconfig",
            //                 principalColumn: "id");
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "auth_group_permissions",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false)
            //                 .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //             group_id = table.Column<int>(type: "integer", nullable: false),
            //             permission_id = table.Column<int>(type: "integer", nullable: false)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_auth_group_permissions", x => x.id);
            //             table.ForeignKey(
            //                 name: "auth_group_permissio_permission_id_84c5c92e_fk_auth_perm",
            //                 column: x => x.permission_id,
            //                 principalTable: "auth_permission",
            //                 principalColumn: "id");
            //             table.ForeignKey(
            //                 name: "auth_group_permissions_group_id_b120cbf9_fk_auth_group_id",
            //                 column: x => x.group_id,
            //                 principalTable: "auth_group",
            //                 principalColumn: "id");
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "auth_user_user_permissions",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false)
            //                 .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //             user_id = table.Column<int>(type: "integer", nullable: false),
            //             permission_id = table.Column<int>(type: "integer", nullable: false)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_auth_user_user_permissions", x => x.id);
            //             table.ForeignKey(
            //                 name: "auth_user_user_permi_permission_id_1fbb5f2c_fk_auth_perm",
            //                 column: x => x.permission_id,
            //                 principalTable: "auth_permission",
            //                 principalColumn: "id");
            //             table.ForeignKey(
            //                 name: "auth_user_user_permissions_user_id_a95ead1b_fk_auth_user_id",
            //                 column: x => x.user_id,
            //                 principalTable: "auth_user",
            //                 principalColumn: "id");
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "home_interested",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('mainapp_home_interested_id_seq'::regclass)"),
            //             home_id = table.Column<int>(type: "integer", nullable: false),
            //             user_id = table.Column<int>(type: "integer", nullable: false)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_home_interested", x => x.id);
            //             table.ForeignKey(
            //                 name: "mainapp_home_interested_home_id_263ffd84_fk_mainapp_home_id",
            //                 column: x => x.home_id,
            //                 principalTable: "home",
            //                 principalColumn: "id");
            //             table.ForeignKey(
            //                 name: "mainapp_home_interested_user_id_32383c2b_fk_auth_user_id",
            //                 column: x => x.user_id,
            //                 principalTable: "auth_user",
            //                 principalColumn: "id");
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "imagelink",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('mainapp_homeimagelink_id_seq'::regclass)"),
            //             link = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
            //             home_fk_id = table.Column<int>(type: "integer", nullable: true)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_imagelink", x => x.id);
            //             table.ForeignKey(
            //                 name: "mainapp_homeimagelink_home_fk_id_467c2a69_fk_mainapp_home_id",
            //                 column: x => x.home_fk_id,
            //                 principalTable: "home",
            //                 principalColumn: "id");
            //         });
            //
            //     migrationBuilder.CreateTable(
            //         name: "room",
            //         columns: table => new
            //         {
            //             id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('mainapp_room_id_seq'::regclass)"),
            //             name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
            //             location = table.Column<string>(type: "character varying(125)", maxLength: 125, nullable: true),
            //             room_size = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
            //             home_fk_id = table.Column<int>(type: "integer", nullable: true)
            //         },
            //         constraints: table =>
            //         {
            //             table.PrimaryKey("PK_room", x => x.id);
            //             table.ForeignKey(
            //                 name: "mainapp_room_home_fk_id_20c7a123_fk_mainapp_home_id",
            //                 column: x => x.home_fk_id,
            //                 principalTable: "home",
            //                 principalColumn: "id");
            //         });
            //
            //     migrationBuilder.CreateIndex(
            //         name: "IX_AspNetRoleClaims_RoleId",
            //         table: "AspNetRoleClaims",
            //         column: "RoleId");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "RoleNameIndex",
            //         table: "AspNetRoles",
            //         column: "NormalizedName",
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "IX_AspNetUserClaims_UserId",
            //         table: "AspNetUserClaims",
            //         column: "UserId");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "IX_AspNetUserLogins_UserId",
            //         table: "AspNetUserLogins",
            //         column: "UserId");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "IX_AspNetUserRoles_RoleId",
            //         table: "AspNetUserRoles",
            //         column: "RoleId");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "EmailIndex",
            //         table: "AspNetUsers",
            //         column: "NormalizedEmail");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "UserNameIndex",
            //         table: "AspNetUsers",
            //         column: "NormalizedUserName",
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_group_name_a6ea08ec_like",
            //         table: "auth_group",
            //         column: "name")
            //         .Annotation("Npgsql:IndexOperators", new[] { "varchar_pattern_ops" });
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_group_name_key",
            //         table: "auth_group",
            //         column: "name",
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_group_permissions_group_id_b120cbf9",
            //         table: "auth_group_permissions",
            //         column: "group_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_group_permissions_group_id_permission_id_0cd325b0_uniq",
            //         table: "auth_group_permissions",
            //         columns: new[] { "group_id", "permission_id" },
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_group_permissions_permission_id_84c5c92e",
            //         table: "auth_group_permissions",
            //         column: "permission_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_permission_content_type_id_2f476e4b",
            //         table: "auth_permission",
            //         column: "content_type_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_permission_content_type_id_codename_01ab375a_uniq",
            //         table: "auth_permission",
            //         columns: new[] { "content_type_id", "codename" },
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_user_username_6821ab7c_like",
            //         table: "auth_user",
            //         column: "username")
            //         .Annotation("Npgsql:IndexOperators", new[] { "varchar_pattern_ops" });
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_user_username_key",
            //         table: "auth_user",
            //         column: "username",
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_user_groups_group_id_97559544",
            //         table: "auth_user_groups",
            //         column: "group_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_user_groups_user_id_6a12ed8b",
            //         table: "auth_user_groups",
            //         column: "user_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_user_groups_user_id_group_id_94350c0c_uniq",
            //         table: "auth_user_groups",
            //         columns: new[] { "user_id", "group_id" },
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_user_user_permissions_permission_id_1fbb5f2c",
            //         table: "auth_user_user_permissions",
            //         column: "permission_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_user_user_permissions_user_id_a95ead1b",
            //         table: "auth_user_user_permissions",
            //         column: "user_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "auth_user_user_permissions_user_id_permission_id_14a6b632_uniq",
            //         table: "auth_user_user_permissions",
            //         columns: new[] { "user_id", "permission_id" },
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_brokeragephonenumber_real_estate_broker_fk_id_fd45cbee",
            //         table: "brokeragephonenumber",
            //         column: "real_estate_broker_fk_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "django_admin_log_content_type_id_c4bce8eb",
            //         table: "django_admin_log",
            //         column: "content_type_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "django_admin_log_user_id_c564eba6",
            //         table: "django_admin_log",
            //         column: "user_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "django_content_type_app_label_model_76bd3d3b_uniq",
            //         table: "django_content_type",
            //         columns: new[] { "app_label", "model" },
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "django_q_task_id_32882367_like",
            //         table: "django_q_task",
            //         column: "id")
            //         .Annotation("Npgsql:IndexOperators", new[] { "varchar_pattern_ops" });
            //
            //     migrationBuilder.CreateIndex(
            //         name: "django_session_expire_date_a5c62663",
            //         table: "django_session",
            //         column: "expire_date");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "django_session_session_key_c0390e0f_like",
            //         table: "django_session",
            //         column: "session_key")
            //         .Annotation("Npgsql:IndexOperators", new[] { "varchar_pattern_ops" });
            //
            //     migrationBuilder.CreateIndex(
            //         name: "django_site_domain_a2e37b91_like",
            //         table: "django_site",
            //         column: "domain")
            //         .Annotation("Npgsql:IndexOperators", new[] { "varchar_pattern_ops" });
            //
            //     migrationBuilder.CreateIndex(
            //         name: "django_site_domain_a2e37b91_uniq",
            //         table: "django_site",
            //         column: "domain",
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_address_fk_id_key",
            //         table: "home",
            //         column: "address_fk_id",
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_bath_rooms_137edddd",
            //         table: "home",
            //         column: "bath_rooms");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_bed_rooms_e1dd4d2b",
            //         table: "home",
            //         column: "bed_rooms");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_created_at_274498cc",
            //         table: "home",
            //         column: "created_at");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_generalized_address_3bde2872_like",
            //         table: "home",
            //         column: "generalized_address")
            //         .Annotation("Npgsql:IndexOperators", new[] { "varchar_pattern_ops" });
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_generalized_address_key",
            //         table: "home",
            //         column: "generalized_address",
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_link_url_a7c2ffa4",
            //         table: "home",
            //         column: "link_url");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_link_url_a7c2ffa4_like",
            //         table: "home",
            //         column: "link_url")
            //         .Annotation("Npgsql:IndexOperators", new[] { "varchar_pattern_ops" });
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_mls_number_695b3ba1",
            //         table: "home",
            //         column: "mls_number");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_mls_number_695b3ba1_like",
            //         table: "home",
            //         column: "mls_number")
            //         .Annotation("Npgsql:IndexOperators", new[] { "varchar_pattern_ops" });
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_price_94cbb17b",
            //         table: "home",
            //         column: "price");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_real_estate_broker_fk_id_cd1e8434",
            //         table: "home",
            //         column: "real_estate_broker_fk_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_rent_price_ee9cc280",
            //         table: "home",
            //         column: "rent_price");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_updated_at_2c8b37bc",
            //         table: "home",
            //         column: "updated_at");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_interested_home_id_263ffd84",
            //         table: "home_interested",
            //         column: "home_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_interested_home_id_user_id_93aac0c5_uniq",
            //         table: "home_interested",
            //         columns: new[] { "home_id", "user_id" },
            //         unique: true);
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_home_interested_user_id_32383c2b",
            //         table: "home_interested",
            //         column: "user_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_homeimagelink_home_fk_id_467c2a69",
            //         table: "imagelink",
            //         column: "home_fk_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_location_city_36967550",
            //         table: "location",
            //         column: "city");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_location_city_36967550_like",
            //         table: "location",
            //         column: "city")
            //         .Annotation("Npgsql:IndexOperators", new[] { "varchar_pattern_ops" });
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_location_house_number_881c76ce",
            //         table: "location",
            //         column: "house_number");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_location_house_number_881c76ce_like",
            //         table: "location",
            //         column: "house_number")
            //         .Annotation("Npgsql:IndexOperators", new[] { "varchar_pattern_ops" });
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_location_lat_2905578d",
            //         table: "location",
            //         column: "lat");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_location_long_cfc4fc6a",
            //         table: "location",
            //         column: "long");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_location_postal_code_2d4d36cd",
            //         table: "location",
            //         column: "postal_code");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_location_postal_code_2d4d36cd_like",
            //         table: "location",
            //         column: "postal_code")
            //         .Annotation("Npgsql:IndexOperators", new[] { "varchar_pattern_ops" });
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_room_home_fk_id_20c7a123",
            //         table: "room",
            //         column: "home_fk_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_scrapingsearchlocation_scraping_config_fk_id_6f277334",
            //         table: "searchlocation",
            //         column: "scraping_config_fk_id");
            //
            //     migrationBuilder.CreateIndex(
            //         name: "mainapp_userprofileinfo_user_fk_id_key",
            //         table: "userprofileinfo",
            //         column: "user_fk_id",
            //         unique: true);
            // }
            // catch (Exception e)
            // {
            //     //Console.WriteLine(e);
            // }


            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "auth_group_permissions");

            migrationBuilder.DropTable(
                name: "auth_user_groups");

            migrationBuilder.DropTable(
                name: "auth_user_user_permissions");

            migrationBuilder.DropTable(
                name: "brokeragephonenumber");

            migrationBuilder.DropTable(
                name: "django_admin_log");

            migrationBuilder.DropTable(
                name: "django_migrations");

            migrationBuilder.DropTable(
                name: "django_q_ormq");

            migrationBuilder.DropTable(
                name: "django_q_schedule");

            migrationBuilder.DropTable(
                name: "django_q_task");

            migrationBuilder.DropTable(
                name: "django_session");

            migrationBuilder.DropTable(
                name: "django_site");

            migrationBuilder.DropTable(
                name: "home_interested");

            migrationBuilder.DropTable(
                name: "imagelink");

            migrationBuilder.DropTable(
                name: "landtype");

            migrationBuilder.DropTable(
                name: "room");

            migrationBuilder.DropTable(
                name: "searchlocation");

            migrationBuilder.DropTable(
                name: "useragentname");

            migrationBuilder.DropTable(
                name: "userprofileinfo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "auth_group");

            migrationBuilder.DropTable(
                name: "auth_permission");

            migrationBuilder.DropTable(
                name: "home");

            migrationBuilder.DropTable(
                name: "scraperconfig");

            migrationBuilder.DropTable(
                name: "auth_user");

            migrationBuilder.DropTable(
                name: "django_content_type");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "realestatebroker");
        }
    }
}
