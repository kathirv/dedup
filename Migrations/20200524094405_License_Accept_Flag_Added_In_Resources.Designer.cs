﻿// <auto-generated />
using System;
using Dedup.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Dedup.Migrations
{
    [DbContext(typeof(DeDupContext))]
    [Migration("20200524094405_License_Accept_Flag_Added_In_Resources")]
    partial class License_Accept_Flag_Added_In_Resources
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dedup")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Dedup.Models.AuthTokens", b =>
                {
                    b.Property<string>("auth_id");

                    b.Property<string>("access_token")
                        .IsRequired();

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("expires_in");

                    b.Property<string>("redirect_url");

                    b.Property<string>("refresh_token")
                        .IsRequired();

                    b.Property<string>("session_nonce");

                    b.Property<string>("token_type");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<string>("user_id");

                    b.HasKey("auth_id");

                    b.ToTable("AuthTokens");
                });

            modelBuilder.Entity("Dedup.Models.Connectors", b =>
                {
                    b.Property<int>("connector_id");

                    b.Property<string>("ccid");

                    b.Property<string>("compare_config_json");

                    b.Property<string>("compare_object_fields");

                    b.Property<string>("connector_name");

                    b.Property<int>("connector_type");

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<int?>("custom_schedule_in_minutes");

                    b.Property<int>("dedup_source_type");

                    b.Property<int>("dedup_type");

                    b.Property<int?>("deduped_count");

                    b.Property<string>("dest_config_json");

                    b.Property<string>("dest_object_name");

                    b.Property<string>("dest_schema");

                    b.Property<string>("job_id");

                    b.Property<int?>("non_deduped_count");

                    b.Property<int>("schedule_type");

                    b.Property<string>("src_config_json");

                    b.Property<string>("src_object_fields_json");

                    b.Property<string>("src_object_name");

                    b.Property<string>("src_schema");

                    b.Property<int?>("sync_count");

                    b.Property<DateTime?>("sync_ended_at");

                    b.Property<string>("sync_log_json");

                    b.Property<string>("sync_new_record_filter");

                    b.Property<int>("sync_src");

                    b.Property<DateTime?>("sync_started_at");

                    b.Property<int?>("sync_status");

                    b.Property<string>("sync_update_record_filter");

                    b.Property<int>("two_way_sync_priority");

                    b.Property<int?>("unique_records_count");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.HasKey("connector_id", "ccid");

                    b.HasIndex("ccid");

                    b.HasIndex("connector_id", "ccid")
                        .IsUnique();

                    b.ToTable("Connectors");
                });

            modelBuilder.Entity("Dedup.Models.DeDupSettings", b =>
                {
                    b.Property<string>("ccid");

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<string>("database_config_json");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.HasKey("ccid");

                    b.ToTable("DeDupSettings");
                });

            modelBuilder.Entity("Dedup.Models.PartnerAuthTokens", b =>
                {
                    b.Property<string>("auth_id");

                    b.Property<string>("access_token");

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("expires_in");

                    b.Property<string>("oauth_code");

                    b.Property<DateTime?>("oauth_expired_in");

                    b.Property<int>("oauth_type");

                    b.Property<string>("redirect_url");

                    b.Property<string>("refresh_token");

                    b.Property<string>("session_nonce");

                    b.Property<string>("token_type");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<string>("user_id");

                    b.HasKey("auth_id");

                    b.ToTable("PartnerAuthTokens");
                });

            modelBuilder.Entity("Dedup.Models.Resources", b =>
                {
                    b.Property<string>("uuid");

                    b.Property<string>("app_name");

                    b.Property<string>("callback_url");

                    b.Property<DateTime>("created_at")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime?>("expired_at");

                    b.Property<string>("heroku_id");

                    b.Property<bool?>("is_license_accepted");

                    b.Property<string>("plan");

                    b.Property<string>("private_app_url");

                    b.Property<string>("region");

                    b.Property<DateTime>("updated_at")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("now()");

                    b.Property<string>("user_email");

                    b.Property<string>("user_name");

                    b.Property<string>("user_organization");

                    b.HasKey("uuid");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("Dedup.Models.AuthTokens", b =>
                {
                    b.HasOne("Dedup.Models.Resources", "Resource")
                        .WithOne("AuthToken")
                        .HasForeignKey("Dedup.Models.AuthTokens", "auth_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dedup.Models.Connectors", b =>
                {
                    b.HasOne("Dedup.Models.DeDupSettings", "DeDupSetting")
                        .WithMany("Connectors")
                        .HasForeignKey("ccid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dedup.Models.DeDupSettings", b =>
                {
                    b.HasOne("Dedup.Models.Resources", "Resource")
                        .WithOne("DedupSetting")
                        .HasForeignKey("Dedup.Models.DeDupSettings", "ccid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dedup.Models.PartnerAuthTokens", b =>
                {
                    b.HasOne("Dedup.Models.Resources", "Resource")
                        .WithOne("partnerAuthToken")
                        .HasForeignKey("Dedup.Models.PartnerAuthTokens", "auth_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
