using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopulateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = MigrationUtility.ReadSql(typeof(PopulateData), "20230702190442_PopulateData.sql");
            migrationBuilder.Sql(sql);
        }
    }
}
