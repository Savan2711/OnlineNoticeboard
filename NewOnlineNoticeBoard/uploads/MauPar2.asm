_text segment byte public 'code'
DGROUP GROUP _DATA,_BSS
       ASSUME CS:_text,DS:DGROUP,SS:DGROUP
_text ends

_data segment word public 'DATA'
so db ' Temp in celc : %d faren : %d',0ah,00h
_data ends

_text segment byte public 'code'
public _c2f
public _show
extrn _PRINTF:near

_c2f proc near

push bp
mov bp,sp
push si
mov ax,word ptr[bp+4]
mov dx,9
mul dx
mov bx,5
cwd
idiv bx
mov si,ax
add si,32
mov ax,si
pop si
pop bp
ret

_c2f endp

_show proc near

push word ptr DGROUP:_tempf
push word ptr DGROUP:_tempc
mov ax,offset DGROUP:so
push ax
call near ptr _PRINTF
add sp,6
ret

_show endp
_text ends

_BSS segment word public 'BSS'
extrn _tempf:word
_BSS ends

_DATA segment word public 'DATA'
extrn _tempc:word
_DATA ends

end


