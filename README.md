# SpreadSheet笔试题

# 设计思想
## 对`SpreadSheet`的封装
抽象出`SpreadSheet`用来表示Sheet表格本身,表格中的每一个单元格表示为`SpreadSheetCell`,其中使用结构体`CellPoint`来表示单元格的坐标。
使用二维数组存储`SpreadSheet`表格数值,并对构造器进行私有化(原因: 统一创建`SpreadSheet`的入口)，提供两个创建`SpreadSheet`的方法。其中一个方法提供了创建空的`SpreadSheet`,一个重载方法提供了对创建的`SpreadSheet`的cell表格的赋值。
### 扩展
如果需要对`SpreadSheet`扩展,则可以抽象出`ISheet`接口,应对后期各种`Sheet`的扩展。

## 对指令的封装
抽象出`ICommandParser`对指令的解析，通过客户的的输入解析出相应的命令。并通过命令实现对`SpreadSheet`的**创建**、**插入值**、**修改值**的操作。

### 扩展
当前使用简单工厂模式实现`ICommandParser`，如果考虑到扩展性，可以考虑使用反射的方式实现`ICommandParser`。命令的名称可以通过`XCommand`来命令,通过这样的方式，可以更方便的实现对`SpreadSheet`的操作的扩展。
