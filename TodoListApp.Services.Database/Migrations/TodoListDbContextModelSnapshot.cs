using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace TodoListApp.Services.Database.Migrations
{
    [DbContext(typeof(TodoListDbContext))]
#pragma warning disable IDE0040
    partial class TodoListDbContextModelSnapshot : ModelSnapshot
#pragma warning restore IDE0040
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {

            _ = modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

#pragma warning disable IDE0058
            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);
#pragma warning restore IDE0058

#pragma warning disable IDE0058
            modelBuilder.Entity("TodoListApp.Services.Database.TodoListEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsShared")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfTasks")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TodoLists");
                });
#pragma warning restore IDE0058

        }
    }
}
