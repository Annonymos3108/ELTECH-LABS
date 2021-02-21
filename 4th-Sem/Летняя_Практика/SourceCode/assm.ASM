.386
.model small
.stack 100h
.data
msg1    db "This program created by Arthur Nersisyan for educational practice.",
         10, 13, "Enter matrix WIDTH(max 5)", 10, 13, '$'  
msg2    db 10, 13, "Enter matrix HEIGHT(max 5)", 10, 13, '$'
msg3    db 10, 13, 10, 13, "Initial matrix: ", 10, 13, '$' 
msg4    db 10, 13, "Sorted matrix: ", 10, 13, '$' 
msg5    db 10, 13, "Enter number N"
msg5_w  db 0, "x"
msg5_h  db 0, 10, 13, '$'  
msg6    db 10, 13, "Done.", 10, 13, '$'
matrix1 dw 30 dup (?) 
                
str_tmp	db 5 dup (' '), '$' ; dlya vyvoda chysel
sum_sym db "+ ", '$' 
equal_sym db "= ", '$'
next_line db 10, 13, '$'

.code
start PROC
        mov ax,@data
        mov ds,ax  

        call input_width
        call input_height 
                
        ; vvod matricy           
        push bx
        push cx
        lea di,matrix1
        call input_matrix
        pop cx
        pop bx
            
        ; calculatiya summy
        push bx
        push cx
        lea di,matrix1
        call calc_sum
        pop cx
        pop bx 
        
        mov ah,09h
        lea dx,msg3
        int 21h 
              
        ; vyvod nachalnoy matricy
        push bx
        push cx
        lea di,matrix1
        call output_matrix
        pop cx
        pop bx
        
        ; sortirovka
        push bx
        push cx
        lea di,matrix1
        call sort_matrix
        pop cx
        pop bx
        
        mov ah,09h
        lea dx,msg4
        int 21h 
              
        ; vyvod izmenennoy matricy
        push bx
        push cx
        lea di,matrix1
        call output_matrix
        pop cx
        pop bx   
        
        mov ah,09h
        lea dx,msg6
        int 21h    

        ; vyhod iz programmy
        mov ax,4c00h
        int 21h   
    
    input_height proc
        ; bx -> height
        mov ah,09h
        lea dx,msg2
        int 21h  
    ih_1:  
        mov ah,1
        int 21h
        cmp al,'1'
        jl ih_1
        cmp al,'5'
        jg ih_1 
        
        sub al,'0'
        sub ah,ah
        mov bx,ax               
        ret  
    input_height endp

    input_width proc
        ; cx -> width
        mov ah,09h
        lea dx,msg1
        int 21h  
        
    iw_1:   
        mov ah,1
        int 21h
        cmp al,'1'
        jl iw_1
        cmp al,'5'
        jg iw_1 
        
        sub al,'0'
        sub ah,ah
        mov cx,ax               
        ret  
    input_width endp   

    sort_matrix proc
        ; di - dannye
        ; bx - height 
        dec bx 
        mov cx,bx
        cmp cx, 0
        je sm_ex 
    sm_0:
        push cx
        push di
        mov bx, 1 ; byl li obmen?
        
    sm_1:        
        mov ax,[di + 10]
        cmp [di + 10 + 12],ax
        jae sm_c
        
        ; menyaem mestami
        mov si,di
        add si,6*2
        call xchange_lines
        
        sub bx,bx         
                 
    sm_c:          
        add di,6*2
        loop sm_1 
        pop di
        pop cx
        cmp bx,0
        je sm_0
    sm_ex:         
        ret
    sort_matrix endp

    xchange_lines proc
        ; di - from
        ; si - to
        push cx
        push di
        push si
        mov cx, 6
    xl_1:        
        mov ax,[di]
        mov dx,[si]
        mov [si],ax
        mov [di],dx 
        
        add si,2
        add di,2
                
        loop xl_1
        pop si
        pop di
        pop cx        
        ret
    xchange_lines endp    
        
    calc_sum proc
        ; di - dannye
        ; cx - width
        ; bx - height
    cs_0:      
        push cx
        push di       
        
        sub ax,ax
    cs_1:     
        add ax,[di]
 
        add di,2     
        loop cs_1 
               
        pop di 
        mov [di + 10],ax
           
        pop cx
        add di,6*2 
        dec bx
        jnz cs_0
         
        ret
    
    calc_sum endp

    output_number proc
        ;ax - number
        push di
        push cx
        push si
        push dx
        
        lea di,str_tmp
        mov cx,5 
    on_1:               
        ;mov [di],' ' 
        inc di
        loop on_1
        dec di
        dec di
        
        mov si,10 
    on_2:
        sub dx,dx
        div si        
        add dl,'0'
        mov [di],dl
        dec di
        sub dx,dx
        cmp ax,si
        jge on_2
        jz on_3
        cmp al,0
        jz on_3
        add al,'0'
        mov [di],al    
    on_3:    
        mov ah,09h
        mov dx,di
        int 21h
        
        pop dx
        pop si
        pop cx
        pop di
        ret         
    output_number endp
        
    output_matrix proc
        ; di - dannye
        ; cx - width
        ; bx - height
         
    om_0:      
        push cx
        push di 
    om_1:     
        mov ax,[di]
        call output_number
               
        cmp cx,1
        je om_2
        mov ah,09h
        lea dx,sum_sym
        int 21h

        ; 09h вывод строки на экран.На входе - ds:dx  = адрес строки с символом $ на конце
        ; 21h 

    om_2:
        add di,2     
        loop om_1
        
        pop di
        
        mov ah,09h
        lea dx,equal_sym
        int 21h
        
        mov ax,[di + 10]
        call output_number 
        
        mov ah,09h
        lea dx,next_line
        int 21h
  
        pop cx
        add di,6*2 
        dec bx
        jnz om_0
         
        ret
    output_matrix endp 

    input_matrix proc
        ; di - dannye
        ; cx - width
        ; bx - height 
        
        mov si,10
        sub ax,ax
        
        mov dl,cl
        mov dh,bl 
    im_0:      
        push cx
        push di 
    im_1:     
        push dx                   
        push di
        lea di,msg5_w 
        mov al,dl
        sub al,cl
        add al,'1'
        mov [di],al
        lea di,msg5_h 
        mov al,dh
        sub al,bl
        add al,'1'
        mov [di],al
        pop di    
                              
        mov ah,09h
        lea dx,msg5
        int 21h
        
        pop dx 
        
        sub bp,bp      
        
    im_2:        
    im_3:   mov ah,1 
        int 21h 
        cmp al,0Dh
        je im_5
        cmp al,'0'
        jl im_3
        cmp al,'9'
        jg im_3
        
        push ax
        push dx
        mov ax,bp
        mul si 
        mov bp,ax
        pop dx
        pop ax
        
        sub al,'0'
        sub ah,ah
        
        add bp,ax
        mov [di],bp
        
        cmp bp,1000
        jl im_2
        jmp im_4 
    im_5:
        cmp bp,10
        jl im_3
    im_4:   
               
        add di,2     
        loop im_1
              
        pop di
        pop cx
        add di,6*2 
        dec bx
        jnz im_0 
        ret
    input_matrix endp   

start ENDP
END start