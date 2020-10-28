using FluentMigrator;

namespace Project.Migration
{
    [Migration(1)]
    public class _0001_Project : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Projects")
                .WithColumn("Id").AsInt64().PrimaryKey()
                .WithColumn("Name").AsString();

            Create.Sequence("ProjectSequence").StartWith(1).IncrementBy(1).MinValue(1);
        }
    }
}
