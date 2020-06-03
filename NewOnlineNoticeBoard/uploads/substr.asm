data segment
	stri db "findstrlal$"
	strlen db $-stri
	substri db "la$"
	sublen db $-substri
	msg1 db "String are match$"
	msg2 db "String are not match$"
data ends

code segment
	assume cs:code,ds:data 
	mov ax,data
	mov ds,ax
	mov es,ax
	mov bh,00
	mov bl,strlen
	mov ch,00h
	mov cl,sublen
	mov si,offset stri
	mov di,offset substri
   
   next:dec cx
	jz equal
	cmpsb 
	jz next
	mov cl,sublen
	mov di,offset substri
	dec bx
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
  	mov dx,offset msg1
   	mov ah,09
   	int 21h
   	int 03
code ends

end
