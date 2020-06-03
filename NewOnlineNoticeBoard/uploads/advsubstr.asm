data segment
	stri db "findstrlal$"
	strlen db $-stri
	substri db "la$"
	sublen db $-substri
	msg1 db "String are match$"
	msg2 db "String are not match$"
	arr db 25,25 dup(0)
	ind dw ?
data ends

code segment
	assume cs:code,ds:data 
	mov ax,data
	mov ds,ax
	mov es,ax
	mov bx,offset arr
	mov ind,bx
	mov bh,00
	mov cl,strlen
	mov ch,00h
	mov bl,sublen
	mov si,offset stri
  again:mov di,offset substri
   
   next:dec bx
	jz equal
	cmpsb 
	jz next
	mov bl,sublen
	mov di,offset substri
	dec cx
	jz nequal
	jmp next
	
 nequal:mov dx,offset msg2
	mov ah,09
	int 21h
	int 03
	
  equal:mov al,sublen
  	mov ah,00
  	sub ax,2
  	sub si,ax
  	mov ax,si
  	mov di,ind
  	mov [di],ax
	add ind,2
   	jmp again
code ends

end
