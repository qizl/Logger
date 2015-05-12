Logger
======

项目包括一个读写日志的类库和日志分析工具（针对该日志类库生成的日志文件进行数据检索、分析），希望能够对大家有所帮助。

已实现功能：
1.Log，日志类库
  a.√ 日志加密
  b.√ 多线程写入，控制日志写入速度
2.LogAnalzyer，日志分析工具 
最初需求：在一项目中，需要到日志文件中提取部分数据之前的几行中与其有相同属性的数据，并整理成固定的格式，以便其他程序读取
已实现功能：
  a.√ 打开文件或文件夹读取日志
  b.√ 根据时间段筛选日志
  c.√ 根据关键字筛选日志
    i.允许读取其前后含有某些关键字的数据
  d.√ 日志导出
  e.根据关键字及属性值绘制统计图（曲线图等）
    i.检索数据占总数据的比例
  f.√ 文件监听
