﻿// <auto-generated />
using System;
using Acacia_Back_End.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Acacia_Back_End.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230729152404_reviews")]
    partial class reviews
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("Acacia_Back_End.Core.CustomerReturn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Total")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("CustomerReturns");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<int>("PostalCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Province")
                        .HasColumnType("TEXT");

                    b.Property<string>("Suburb")
                        .HasColumnType("TEXT");

                    b.Property<int>("VatNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.CustomerOrders.DeliveryMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeliveryTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryMethods");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.CustomerOrders.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeliveryMethodId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("GroupElephantDiscount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("SubTotal")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryMethodId");

                    b.HasIndex("OrderTypeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.CustomerOrders.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Promotion")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.CustomerOrders.OrderType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OrderTypes");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.FAQ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .HasColumnType("TEXT");

                    b.Property<string>("Question")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FAQs");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.GiftBox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("GiftBoxImage")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GiftBoxes");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.GiftBoxPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("GiftBoxId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("PackagingCosts")
                        .HasColumnType("REAL");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GiftBoxId");

                    b.ToTable("GiftBoxPrices");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PromotionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("QRCode")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TresholdValue")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex("PromotionId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.ProductPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPrices");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.ProductReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductReviews");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Percentage")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.ReturnItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerReturnId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerReturnId");

                    b.ToTable("ReturnItems");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.Vat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Percentage")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Vats");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.WriteOff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("WriteOffs");
                });

            modelBuilder.Entity("GiftBoxProduct", b =>
                {
                    b.Property<int>("GiftBoxesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GiftBoxesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("GiftBoxProduct");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.CustomerReturn", b =>
                {
                    b.HasOne("Acacia_Back_End.Core.Models.CustomerOrders.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.CustomerOrders.Order", b =>
                {
                    b.HasOne("Acacia_Back_End.Core.Models.CustomerOrders.DeliveryMethod", "DeliveryMethod")
                        .WithMany()
                        .HasForeignKey("DeliveryMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Acacia_Back_End.Core.Models.CustomerOrders.OrderType", "OrderType")
                        .WithMany()
                        .HasForeignKey("OrderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Acacia_Back_End.Core.Models.CustomerOrders.OrderAddress", "ShipToAddress", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("City")
                                .HasColumnType("TEXT");

                            b1.Property<string>("ComplexName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("FirstName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("LastName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Province")
                                .HasColumnType("TEXT");

                            b1.Property<string>("StreetAddress")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Suburb")
                                .HasColumnType("TEXT");

                            b1.Property<string>("TrackingNumber")
                                .HasColumnType("TEXT");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("DeliveryMethod");

                    b.Navigation("OrderType");

                    b.Navigation("ShipToAddress")
                        .IsRequired();
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.CustomerOrders.OrderItem", b =>
                {
                    b.HasOne("Acacia_Back_End.Core.Models.CustomerOrders.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Acacia_Back_End.Core.Models.CustomerOrders.ProductOrdered", "ItemOrdered", b1 =>
                        {
                            b1.Property<int>("OrderItemId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("ProductItemId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("ProductName")
                                .HasColumnType("TEXT");

                            b1.Property<string>("ProductUrl")
                                .HasColumnType("TEXT");

                            b1.HasKey("OrderItemId");

                            b1.ToTable("OrderItems");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemId");
                        });

                    b.Navigation("ItemOrdered");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.GiftBoxPrice", b =>
                {
                    b.HasOne("Acacia_Back_End.Core.Models.GiftBox", null)
                        .WithMany("PriceHistory")
                        .HasForeignKey("GiftBoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.Product", b =>
                {
                    b.HasOne("Acacia_Back_End.Core.Models.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Acacia_Back_End.Core.Models.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Acacia_Back_End.Core.Models.Promotion", "Promotion")
                        .WithMany("Products")
                        .HasForeignKey("PromotionId");

                    b.HasOne("Acacia_Back_End.Core.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.Navigation("ProductCategory");

                    b.Navigation("ProductType");

                    b.Navigation("Promotion");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.ProductPrice", b =>
                {
                    b.HasOne("Acacia_Back_End.Core.Models.Product", null)
                        .WithMany("PriceHistory")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.ProductReview", b =>
                {
                    b.HasOne("Acacia_Back_End.Core.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.ReturnItem", b =>
                {
                    b.HasOne("Acacia_Back_End.Core.CustomerReturn", null)
                        .WithMany("ReturnItems")
                        .HasForeignKey("CustomerReturnId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.WriteOff", b =>
                {
                    b.HasOne("Acacia_Back_End.Core.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GiftBoxProduct", b =>
                {
                    b.HasOne("Acacia_Back_End.Core.Models.GiftBox", null)
                        .WithMany()
                        .HasForeignKey("GiftBoxesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Acacia_Back_End.Core.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Acacia_Back_End.Core.CustomerReturn", b =>
                {
                    b.Navigation("ReturnItems");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.CustomerOrders.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.GiftBox", b =>
                {
                    b.Navigation("PriceHistory");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.Product", b =>
                {
                    b.Navigation("PriceHistory");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.Promotion", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Acacia_Back_End.Core.Models.Supplier", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
