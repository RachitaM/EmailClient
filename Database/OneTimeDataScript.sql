IF NOT EXISTS(SELECT 1 FROM dbo.[UserLogin] where UserName ='demouser@macrosoft.com')
BEGIN
insert into dbo.[UserLogin]( UserName, Password, IsDeleted, CreatedDate, UpdatedDate)
values ( 'demouser@macrosoft.com','Test_1234', 0, GETDATE(), GETDATE())
END


insert into dbo.Profile( Fname, MName, LName, Address,CreatedDate, UpdatedDate)
values ( 'John','Denzil' ,'Menezes','Verna Goa', GETDATE(), GETDATE())

insert into dbo.EmailFolderType( Name, Description, InUse)
values ( 'Inbox','' ,1)

insert into dbo.EmailFolderType( Name, Description, InUse)
values ( 'Sent Items','' ,1)

insert into dbo.EmailFolderType( Name, Description, InUse)
values ( 'Drafts','' ,1)


insert into dbo.EmailFolderType( Name, Description, InUse)
values ( 'Junk Emails','' ,1)

insert into dbo.EmailFolderType( Name, Description, InUse)
values ( 'Favorites','' ,1)

insert into dbo.EmailFolderType( Name, Description, InUse)
values ( 'Archive','' ,1)

select * from [UserLogin]

select * from [Profile]

select * from EmailFolderType

select * from EMailMessage


select * from EmailRecipient