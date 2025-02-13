﻿// <auto-generated />
using Antivirus.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Antivirus.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Antivirus.Models.bootcamps", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<long?>("id_costos_id")
                        .HasColumnType("bigint");

                    b.Property<long?>("id_estado_id")
                        .HasColumnType("bigint");

                    b.Property<long?>("id_general_id")
                        .HasColumnType("bigint");

                    b.Property<long?>("id_temas_id")
                        .HasColumnType("bigint");

                    b.Property<string>("informacion")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<char?>("trial751")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_bootcamps");

                    b.HasIndex("id_costos_id");

                    b.HasIndex("id_estado_id");

                    b.HasIndex("id_general_id");

                    b.HasIndex("id_temas_id");

                    b.ToTable("bootcamps");
                });

            modelBuilder.Entity("Antivirus.Models.categories_opportunities", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("categories")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<char?>("trial751")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_categories_opportunities");

                    b.ToTable("categories_opportunities");
                });

            modelBuilder.Entity("Antivirus.Models.costs_bootcamps", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("costs")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<char?>("trial751")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_costs_bootcamps");

                    b.ToTable("costs_bootcamps");
                });

            modelBuilder.Entity("Antivirus.Models.descriptions_bootcamps", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<char?>("trial751")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_descriptions_bootcamps");

                    b.ToTable("descriptions_bootcamps");
                });

            modelBuilder.Entity("Antivirus.Models.institute_bootcamps", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<long?>("id_bootcamps")
                        .HasColumnType("bigint");

                    b.Property<long?>("id_institutions")
                        .HasColumnType("bigint");

                    b.Property<char?>("trial755")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_institute_bootcamps");

                    b.HasIndex("id_bootcamps");

                    b.HasIndex("id_institutions");

                    b.ToTable("institute_bootcamps");
                });

            modelBuilder.Entity("Antivirus.Models.institute_opportunities", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<long?>("id_institutions")
                        .HasColumnType("bigint");

                    b.Property<long?>("id_opportunities")
                        .HasColumnType("bigint");

                    b.Property<char?>("trial755")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_institute_opportunities");

                    b.HasIndex("id_institutions");

                    b.HasIndex("id_opportunities");

                    b.ToTable("institute_opportunities");
                });

            modelBuilder.Entity("Antivirus.Models.institutions", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("bienestar_link")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("carer_link")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("directions")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("general_link")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<long?>("id_status")
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("observations")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("procces_link")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<char?>("trial751")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.Property<long?>("ubications_institutions")
                        .HasColumnType("bigint");

                    b.HasKey("id")
                        .HasName("pk_institutions");

                    b.HasIndex("id_status");

                    b.HasIndex("ubications_institutions");

                    b.ToTable("institutions");
                });

            modelBuilder.Entity("Antivirus.Models.opportunities", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("adicional_dates")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("applications")
                        .HasMaxLength(144)
                        .HasColumnType("character varying(144)");

                    b.Property<string>("contact_channels")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("descriptions")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("guide")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<long?>("id_categories")
                        .HasColumnType("bigint");

                    b.Property<long?>("id_status_review")
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("observations")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<long?>("oportunity_type")
                        .HasColumnType("bigint");

                    b.Property<string>("requeriments")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<char?>("trial755")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_opportunities");

                    b.HasIndex("id_categories");

                    b.HasIndex("id_status_review");

                    b.HasIndex("oportunity_type");

                    b.ToTable("opportunities");
                });

            modelBuilder.Entity("Antivirus.Models.role", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<char?>("trial755")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_role");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Antivirus.Models.status_bootcamps", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("status")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<char?>("trial751")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_status_bootcamps");

                    b.ToTable("status_bootcamps");
                });

            modelBuilder.Entity("Antivirus.Models.status_institutions", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("status_review")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<char?>("trial751")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_status_institutions");

                    b.ToTable("status_institutions");
                });

            modelBuilder.Entity("Antivirus.Models.status_opportunities", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("status")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<char?>("trial755")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_status_opportunities");

                    b.ToTable("status_opportunities");
                });

            modelBuilder.Entity("Antivirus.Models.topics_bootcamps", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("topics")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<char?>("trial751")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_topics_bootcamps");

                    b.ToTable("topics_bootcamps");
                });

            modelBuilder.Entity("Antivirus.Models.type_opportunities", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("oportunity_type")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<char?>("trial755")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_type_opportunities");

                    b.ToTable("type_opportunities");
                });

            modelBuilder.Entity("Antivirus.Models.ubications_institutions", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<char?>("trial751")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.Property<string>("zona")
                        .HasMaxLength(144)
                        .HasColumnType("character varying(144)");

                    b.HasKey("id")
                        .HasName("pk_ubications_institutions");

                    b.ToTable("ubications_institutions");
                });

            modelBuilder.Entity("Antivirus.Models.user_oportunities", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<long?>("id_opportunity")
                        .HasColumnType("bigint");

                    b.Property<long?>("id_user")
                        .HasColumnType("bigint");

                    b.Property<char?>("trial755")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_user_oportunities");

                    b.HasIndex("id_opportunity");

                    b.HasIndex("id_user");

                    b.ToTable("user_oportunities");
                });

            modelBuilder.Entity("Antivirus.Models.user_roles", b =>
                {
                    b.Property<long>("users_id")
                        .HasColumnType("bigint");

                    b.Property<long>("role_id")
                        .HasColumnType("bigint");

                    b.Property<char?>("trial755")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("users_id", "role_id")
                        .HasName("pk_user_roles");

                    b.HasIndex("role_id");

                    b.ToTable("user_roles");
                });

            modelBuilder.Entity("Antivirus.Models.users", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<string>("date_birth")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("email")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("last_name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("name")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("password")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<char?>("trial755")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_users");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Antivirus.Models.users_bootcamps", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("id"));

                    b.Property<long?>("id_bootcamp")
                        .HasColumnType("bigint");

                    b.Property<long?>("id_usuario")
                        .HasColumnType("bigint");

                    b.Property<char?>("trial755")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)");

                    b.HasKey("id")
                        .HasName("pk_users bootcamps");

                    b.HasIndex("id_bootcamp");

                    b.HasIndex("id_usuario");

                    b.ToTable("users bootcamps");
                });

            modelBuilder.Entity("Antivirus.Models.bootcamps", b =>
                {
                    b.HasOne("Antivirus.Models.costs_bootcamps", "id_costos")
                        .WithMany("bootcamps")
                        .HasForeignKey("id_costos_id")
                        .HasConstraintName("fk9xuiavb96354u5fyqqgdidje2");

                    b.HasOne("Antivirus.Models.status_bootcamps", "id_estado")
                        .WithMany("bootcamps")
                        .HasForeignKey("id_estado_id")
                        .HasConstraintName("fkf0hwerqfhhpsjsg0hyp6t9xay");

                    b.HasOne("Antivirus.Models.descriptions_bootcamps", "id_general")
                        .WithMany("bootcamps")
                        .HasForeignKey("id_general_id")
                        .HasConstraintName("fkjv4fduf6dkh5gp1gy6k9uyngw");

                    b.HasOne("Antivirus.Models.topics_bootcamps", "id_temas")
                        .WithMany("bootcamps")
                        .HasForeignKey("id_temas_id")
                        .HasConstraintName("fkqw8goqpav8guq2u2dp06l9fco");

                    b.Navigation("id_costos");

                    b.Navigation("id_estado");

                    b.Navigation("id_general");

                    b.Navigation("id_temas");
                });

            modelBuilder.Entity("Antivirus.Models.institute_bootcamps", b =>
                {
                    b.HasOne("Antivirus.Models.bootcamps", "id_bootcampsNavigation")
                        .WithMany("institute_bootcamps")
                        .HasForeignKey("id_bootcamps")
                        .HasConstraintName("fkibgmi914ixp8n15q6r98e35j0");

                    b.HasOne("Antivirus.Models.institutions", "id_institutionsNavigation")
                        .WithMany("institute_bootcamps")
                        .HasForeignKey("id_institutions")
                        .HasConstraintName("fk94xtqb83b39kr2eg5ruccm5bo");

                    b.Navigation("id_bootcampsNavigation");

                    b.Navigation("id_institutionsNavigation");
                });

            modelBuilder.Entity("Antivirus.Models.institute_opportunities", b =>
                {
                    b.HasOne("Antivirus.Models.institutions", "id_institutionsNavigation")
                        .WithMany("institute_opportunities")
                        .HasForeignKey("id_institutions")
                        .HasConstraintName("fkford1un3y2i3d2u784xukenqy");

                    b.HasOne("Antivirus.Models.opportunities", "id_opportunitiesNavigation")
                        .WithMany("institute_opportunities")
                        .HasForeignKey("id_opportunities")
                        .HasConstraintName("fkmfll2parmn67irst86mw41kih");

                    b.Navigation("id_institutionsNavigation");

                    b.Navigation("id_opportunitiesNavigation");
                });

            modelBuilder.Entity("Antivirus.Models.institutions", b =>
                {
                    b.HasOne("Antivirus.Models.status_institutions", "id_statusNavigation")
                        .WithMany("institutions")
                        .HasForeignKey("id_status")
                        .HasConstraintName("fk8eogasiuqctsewhguwkwkcd60");

                    b.HasOne("Antivirus.Models.ubications_institutions", "ubications_institutionsNavigation")
                        .WithMany("institutions")
                        .HasForeignKey("ubications_institutions")
                        .HasConstraintName("fk5as0aeai7nx6n5vgarqharpal");

                    b.Navigation("id_statusNavigation");

                    b.Navigation("ubications_institutionsNavigation");
                });

            modelBuilder.Entity("Antivirus.Models.opportunities", b =>
                {
                    b.HasOne("Antivirus.Models.categories_opportunities", "id_categoriesNavigation")
                        .WithMany("opportunities")
                        .HasForeignKey("id_categories")
                        .HasConstraintName("fkh9cuofel5n7uyh82ktwnbh1c7");

                    b.HasOne("Antivirus.Models.status_opportunities", "id_status_reviewNavigation")
                        .WithMany("opportunities")
                        .HasForeignKey("id_status_review")
                        .HasConstraintName("fkfalcps2a9hij52b0ho66hfvme");

                    b.HasOne("Antivirus.Models.type_opportunities", "oportunity_typeNavigation")
                        .WithMany("opportunities")
                        .HasForeignKey("oportunity_type")
                        .HasConstraintName("fklnmbgi82s4mmp6sxi0v09jr8n");

                    b.Navigation("id_categoriesNavigation");

                    b.Navigation("id_status_reviewNavigation");

                    b.Navigation("oportunity_typeNavigation");
                });

            modelBuilder.Entity("Antivirus.Models.user_oportunities", b =>
                {
                    b.HasOne("Antivirus.Models.opportunities", "id_opportunityNavigation")
                        .WithMany("user_oportunities")
                        .HasForeignKey("id_opportunity")
                        .HasConstraintName("fk38p2dg6rit712540p57c2pe67");

                    b.HasOne("Antivirus.Models.users", "id_userNavigation")
                        .WithMany("user_oportunities")
                        .HasForeignKey("id_user")
                        .HasConstraintName("fknx8chpjucnvb00t8rpc77dcpk");

                    b.Navigation("id_opportunityNavigation");

                    b.Navigation("id_userNavigation");
                });

            modelBuilder.Entity("Antivirus.Models.user_roles", b =>
                {
                    b.HasOne("Antivirus.Models.role", "role")
                        .WithMany("user_roles")
                        .HasForeignKey("role_id")
                        .IsRequired()
                        .HasConstraintName("fkrhfovtciq1l558cw6udg0h0d3");

                    b.HasOne("Antivirus.Models.users", "users")
                        .WithMany("user_roles")
                        .HasForeignKey("users_id")
                        .IsRequired()
                        .HasConstraintName("fkoovdgg7vvr1hb8vw6ivcrv3tb");

                    b.Navigation("role");

                    b.Navigation("users");
                });

            modelBuilder.Entity("Antivirus.Models.users_bootcamps", b =>
                {
                    b.HasOne("Antivirus.Models.bootcamps", "id_bootcampNavigation")
                        .WithMany("users_bootcamps")
                        .HasForeignKey("id_bootcamp")
                        .HasConstraintName("fkqp5qxld9th4l8mwfymb9ttjpa");

                    b.HasOne("Antivirus.Models.users", "id_usuarioNavigation")
                        .WithMany("users_bootcamps")
                        .HasForeignKey("id_usuario")
                        .HasConstraintName("fk1psvppbmh5hflxjklfhljc885");

                    b.Navigation("id_bootcampNavigation");

                    b.Navigation("id_usuarioNavigation");
                });

            modelBuilder.Entity("Antivirus.Models.bootcamps", b =>
                {
                    b.Navigation("institute_bootcamps");

                    b.Navigation("users_bootcamps");
                });

            modelBuilder.Entity("Antivirus.Models.categories_opportunities", b =>
                {
                    b.Navigation("opportunities");
                });

            modelBuilder.Entity("Antivirus.Models.costs_bootcamps", b =>
                {
                    b.Navigation("bootcamps");
                });

            modelBuilder.Entity("Antivirus.Models.descriptions_bootcamps", b =>
                {
                    b.Navigation("bootcamps");
                });

            modelBuilder.Entity("Antivirus.Models.institutions", b =>
                {
                    b.Navigation("institute_bootcamps");

                    b.Navigation("institute_opportunities");
                });

            modelBuilder.Entity("Antivirus.Models.opportunities", b =>
                {
                    b.Navigation("institute_opportunities");

                    b.Navigation("user_oportunities");
                });

            modelBuilder.Entity("Antivirus.Models.role", b =>
                {
                    b.Navigation("user_roles");
                });

            modelBuilder.Entity("Antivirus.Models.status_bootcamps", b =>
                {
                    b.Navigation("bootcamps");
                });

            modelBuilder.Entity("Antivirus.Models.status_institutions", b =>
                {
                    b.Navigation("institutions");
                });

            modelBuilder.Entity("Antivirus.Models.status_opportunities", b =>
                {
                    b.Navigation("opportunities");
                });

            modelBuilder.Entity("Antivirus.Models.topics_bootcamps", b =>
                {
                    b.Navigation("bootcamps");
                });

            modelBuilder.Entity("Antivirus.Models.type_opportunities", b =>
                {
                    b.Navigation("opportunities");
                });

            modelBuilder.Entity("Antivirus.Models.ubications_institutions", b =>
                {
                    b.Navigation("institutions");
                });

            modelBuilder.Entity("Antivirus.Models.users", b =>
                {
                    b.Navigation("user_oportunities");

                    b.Navigation("user_roles");

                    b.Navigation("users_bootcamps");
                });
#pragma warning restore 612, 618
        }
    }
}
