using System.Linq;

using RazorSharp.Components.Data;
using RazorSharp.Framework.Components.Data;
using RazorSharp.Tests.TestDoubles.Fakes;

public sealed class CellChangeManagerTests
{
    public sealed class Edit : TestContext
    {
        [Fact]
        public void Should_edit_the_value_and_store_it_on_the_context()
        {
            var cellChangeManager = new CellChangeManager<FakePerson>();

            var item = new FakePerson { Name = "John Smith" };
            var property = item.GetType().GetProperties().First();
            var context = new GridCellDataContext<FakePerson>(item, property);

            var isEdited = cellChangeManager.Edit(context, "John Doe");

            Assert.Multiple(() => Assert.Equal("John Smith", item.Name),
                            () => Assert.Equal("John Smith", context.OriginalValue),
                            () => Assert.Equal("John Doe", context.CurrentValue),
                            () => Assert.True(isEdited));
        }
    }

    public sealed class Remove : TestContext
    {
        [Fact]
        public void Should_remove_the_tracked_items_and_cells()
        {
            var cellChangeManager = new CellChangeManager<FakePerson>();

            var item = new FakePerson { Name = "John Smith" };
            var property = item.GetType().GetProperties().First();
            var context = new GridCellDataContext<FakePerson>(item, property);

            cellChangeManager.Edit(context, "John Doe");

            var trackedItems = cellChangeManager.TrackedItems;
            var trackedCells = cellChangeManager.TrackedCells;

            cellChangeManager.Remove(item);

            var currentTrackedItems = cellChangeManager.TrackedItems;
            var currentTrackedCells = cellChangeManager.TrackedCells;

            Assert.Multiple(() => Assert.Equal(1, trackedItems),
                            () => Assert.Equal(1, trackedCells),
                            () => Assert.Equal(0, currentTrackedItems),
                            () => Assert.Equal(0, currentTrackedCells));
        }
    }

    public sealed class SaveChanges : TestContext
    {
        [Fact]
        public void Should_save_the_changes_to_the_item()
        {
            var cellChangeManager = new CellChangeManager<FakePerson>();

            var item = new FakePerson { Name = "John Smith" };
            var property = item.GetType().GetProperties().First();
            var context = new GridCellDataContext<FakePerson>(item, property);

            cellChangeManager.Edit(context, "John Doe");

            var isSaved = cellChangeManager.SaveChanges(item);

            Assert.Multiple(() => Assert.Equal("John Doe", item.Name),
                            () => Assert.Equal("John Doe", context.OriginalValue),
                            () => Assert.Equal("John Doe", context.CurrentValue),
                            () => Assert.True(isSaved));
        }
    }
}