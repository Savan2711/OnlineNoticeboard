data segment
	n1 db 12h
	n2 db 67h
data ends
code segment
	assume ds:data,cs:code
	mov ax,data
	mov ds,ax
	mov al,n1
	mov bl,n2
	mov si,2000h
	mov [si],al
	mov di,3000h
	mov [di],bl
	mov ax,[si]
	xchg [di],ax
	mov [si],ax
	int 03
code ends

end
