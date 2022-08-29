namespace CopyNotionApi3.Entities;

public class Block<T>
{
    public int Id { get; set; }
    public Block<object> Parent { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime LastEditedTime { get; set; }
    public User CreatedBy { get; set; }
    public User LastEditedBy { get; set; }

    public BlockType BlockType { get; set; }
    public T Attr { get; set; }

}
