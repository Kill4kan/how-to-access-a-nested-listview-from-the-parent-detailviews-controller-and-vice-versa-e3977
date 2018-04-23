;#DropDB WinExampleEasyTest

#Application WinExample.Win

*Action Navigation(User)

*ProcessRecord
 User Name = [DomainUserName]
 
*FillForm
 User Name = Test User
 
*Action Cancel

*HandleDialog
 Respond = Yes

*CheckFieldValues
 User Name = [DomainUserName]

