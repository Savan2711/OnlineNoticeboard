data segment
	arr dw 08h,09h,05h,25h,13h
	len dw $-arr
	min dw ?
	temp dw ?
data ends 

code segment
	assume ds:data,cs:code
	mov ax,data
	mov ds,ax
	lea si,arr
	mov ax,len
	mov bx,2
	div bx
	mov len,ax
	mov cx,len
	mov dx,len
	mov bx,[si]
	mov dx,si
	x2:inc si
	   inc si
	   cmp bx,[si]
 	   jnc x1
	   dec cx
	   jz halt
	   jmp x2
	x1:mov bx,[si]
	   dec cx
	   jz halt
	   jmp x2
	halt:mov di,dx
	     mov [di],bx
	     mov temp,ax
	     sub ax,len
	     add si,ax
	     mov ax,temp
	     dec ax
	     jz halt1
	     jmp x2
	halt1:     
	    int 03
code ends

end
