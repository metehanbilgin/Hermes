using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hermes.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conversation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    User_One = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    User_Two = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conversation_users",
                        column: x => x.User_One,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conversation_users1",
                        column: x => x.User_Two,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FriendList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    FriendId = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    MessageTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    NewMessage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendList_users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendList_users1",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConversationsReplies",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    reply = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id_fk = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    time = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    c_id_fk = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationsReplies", x => x.id);
                    table.ForeignKey(
                        name: "FK_conversation_reply_conversation",
                        column: x => x.c_id_fk,
                        principalTable: "Conversation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_conversation_reply_users1",
                        column: x => x.user_id_fk,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_User_One",
                table: "Conversation",
                column: "User_One");

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_User_Two",
                table: "Conversation",
                column: "User_Two");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationsReplies_c_id_fk",
                table: "ConversationsReplies",
                column: "c_id_fk");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationsReplies_user_id_fk",
                table: "ConversationsReplies",
                column: "user_id_fk");

            migrationBuilder.CreateIndex(
                name: "IX_FriendList_FriendId",
                table: "FriendList",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendList_UserId",
                table: "FriendList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversationsReplies");

            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropTable(
                name: "Conversation");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
