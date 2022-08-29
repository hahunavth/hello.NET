﻿namespace CopyNotionApi3.Entities;
public enum BlockType
{
    paragraph, heading_1, heading_2, heading_3,
    bulleted_list_item, numbered_list_item, to_do, toggle,
    child_page, child_database, embed, image,
    video, file, pdf, bookmark,
    callout, quote, equation, divider,
    table_of_contents, column, column_list, link_preview,
    synced_block, template, link_to_page, table,
    table_row, unsuported
}