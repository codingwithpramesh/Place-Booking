using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FINALALL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComment_posts_PostsId",
                table: "MainComment");

            migrationBuilder.DropForeignKey(
                name: "FK_SubComment_MainComment_MainCommentId",
                table: "SubComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubComment",
                table: "SubComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainComment",
                table: "MainComment");

            migrationBuilder.RenameTable(
                name: "SubComment",
                newName: "SubComments");

            migrationBuilder.RenameTable(
                name: "MainComment",
                newName: "MainComments");

            migrationBuilder.RenameIndex(
                name: "IX_SubComment_MainCommentId",
                table: "SubComments",
                newName: "IX_SubComments_MainCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_MainComment_PostsId",
                table: "MainComments",
                newName: "IX_MainComments_PostsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubComments",
                table: "SubComments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainComments",
                table: "MainComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainComments_posts_PostsId",
                table: "MainComments",
                column: "PostsId",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubComments_MainComments_MainCommentId",
                table: "SubComments",
                column: "MainCommentId",
                principalTable: "MainComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainComments_posts_PostsId",
                table: "MainComments");

            migrationBuilder.DropForeignKey(
                name: "FK_SubComments_MainComments_MainCommentId",
                table: "SubComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubComments",
                table: "SubComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainComments",
                table: "MainComments");

            migrationBuilder.RenameTable(
                name: "SubComments",
                newName: "SubComment");

            migrationBuilder.RenameTable(
                name: "MainComments",
                newName: "MainComment");

            migrationBuilder.RenameIndex(
                name: "IX_SubComments_MainCommentId",
                table: "SubComment",
                newName: "IX_SubComment_MainCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_MainComments_PostsId",
                table: "MainComment",
                newName: "IX_MainComment_PostsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubComment",
                table: "SubComment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainComment",
                table: "MainComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainComment_posts_PostsId",
                table: "MainComment",
                column: "PostsId",
                principalTable: "posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubComment_MainComment_MainCommentId",
                table: "SubComment",
                column: "MainCommentId",
                principalTable: "MainComment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
