set sysmenu to
set resource off
set exclusive off
set status bar off
set deleted on
set safety off
set multilocks on
set collate to "machine"
set notify  off
set talk off
set optimize on
set century on
set exact on
set date to taiwan
set escape off  &&關閉執行遠端sql指令的等待訊息

do form 表單1.scx
read event

set sysmenu to default
return
