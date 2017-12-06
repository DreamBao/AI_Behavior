# AI_Behavior
AI Behavior Tree

# Process
1.行为树的功能需要哪些节点

2.节点的数据结构如何定义

3.建立的编辑器需要达成那些功能

4.如何无限制的在编辑器中创建自己想要的节点

5.如何把编辑器中的节点用行为树的方式组织连接起来
	用List<Child>的方式，对于parent节点把所有的孩子节点都组织起来，然后按照不同节点的规则依次访问

6.如何保证数据的存储和重复利用
	考虑了很久，决定使用Json数据来存储导出的相关节点及链接信息，有利于跨平台和解析
	直接在编辑器中编辑后存储的方式采用Unity当中的SerializeField
