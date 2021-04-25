using Microsoft.EntityFrameworkCore.Migrations;

namespace ITInventory.Migrations
{
    public partial class comboboxvaluegenerate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE TRIGGER [Metadata].[WeightedComboBoxItem_UPDATE] ON [Metadata].[ComboBoxItems]
                    AFTER UPDATE
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        
                        IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;
                        DECLARE @Name nvarchar(450)
                        DECLARE @UserId nvarchar(450)

                        SELECT @Name = INSERTED.Name, 
                               @UserId = INSERTED.UserId
                        FROM INSERTED

                        UPDATE [Metadata].[ComboBoxItems]
                        SET LastUsed = GETDATE(), 
                             Uses = ((SELECT Uses 
                                      FROM [Metadata].[ComboBoxItes] 
                                      WHERE Name = @Name AND UserId = @UserId) + 1)
                        WHERE Name = @Name AND UserId = @UserId
                    END");
            migrationBuilder.Sql(
                @"CREATE TRIGGER [Metadata].[WeightedComboBoxItem_INSERT] ON [Metadata].[ComboBoxItems]
                    AFTER INSERT
                    AS
                    BEGIN
                        SET NOCOUNT ON;
                        
                        IF ((SELECT TRIGGER_NESTLEVEL()) > 1) RETURN;
                        DECLARE @Name nvarchar(450)
                        DECLARE @UserId nvarchar(450)

                        SELECT @Name = INSERTED.Name,
                               @UserId = INSERTED.UserId
                        FROM INSERTED

                        UPDATE [Metadata].[ComboBoxItems]
                        SET LastUsed = GETDATE(),
                             Uses = 1
                        WHERE Name = @Name AND UserId = @UserId
                    END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
