using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FinalText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_posts_PostsId",
                table: "MainComments");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "posts");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "posts",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "Tags",
                table: "posts",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "Descriptions",
                table: "posts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "posts",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "PostsId",
                table: "MainComments",
                newName: "PlacesId");

            migrationBuilder.RenameIndex(
                name: "IX_MainComments_PostsId",
                table: "MainComments",
                newName: "IX_MainComments_PlacesId");

            migrationBuilder.AddColumn<int>(
                name: "PostsId",
                table: "reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Roles",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "order",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "registerId",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Places",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_PostsId",
                table: "reviews",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_PlaceId",
                table: "posts",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_registerId",
                table: "posts",
                column: "registerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_Places_PlacesId",
                table: "MainComments",
                column: "PlacesId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_Places_PlaceId",
                table: "posts",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_Register_registerId",
                table: "posts",
                column: "registerId",
                principalTable: "Register",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_posts_PostsId",
                table: "reviews",
                column: "PostsId",
                principalTable: "posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_Places_PlacesId",
                table: "MainComments");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_Places_PlaceId",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_Register_registerId",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_posts_PostsId",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_PostsId",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_posts_PlaceId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_registerId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "PostsId",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "Roles",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "order",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "registerId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "posts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "posts",
                newName: "Tags");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "posts",
                newName: "Descriptions");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "posts",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "PlacesId",
                table: "MainComments",
                newName: "PostsId");

            migrationBuilder.RenameIndex(
                name: "IX_MainComments_PlacesId",
                table: "MainComments",
                newName: "IX_MainComments_PostsId");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_posts_PostsId",
                table: "MainComments",
                column: "PostsId",
                principalTable: "posts",
                principalColumn: "Id");
        }
    }
}
