//import {ref} from 'vue'
const main_access = import.meta.env.VITE_API_URL

type PostType = {
    cliente : string,
    total : number
}
type PutType = {
    cliente : string,
    fecha : string,
    total : number
}

export async function GetOrders(){
    try {
        const res = await fetch(main_access)
        const data = await res.json()

        //console.log(data)

        if (!data){
            return null
        }else{
            return data
        }

    }catch(error){
        return null
    }

}

export async function PostOrders(payloadPost:PostType){
    //console.log(cliente, total)
    try{
        const res = await fetch(main_access, {
            method: 'POST',
            headers: {
                'Content-Type':'application/json',
            },body: JSON.stringify(payloadPost),
        });

        if(res.ok || res){
            return res
        }

    }catch(error){
        if(error instanceof Error){
            return error??null
        }
        return error
    }
}

export async function DeleteOrder(id : string){
    const res = await fetch(main_access+id,{method: 'DELETE'});
    try {
        if (res){
            return true
        }else{
            return false
        }
    }catch(error){
        return false
    }
} 

export async function GetOneOrder(id: string) {
    if (!id || id.trim() === "") {
        console.warn("ID vacío o inválido");
        throw new Error("Error al modificar el cliente.")
    }

    try {
        const res : Response = await fetch(main_access+id);
        if (res.status == 400 || !res) {
            //console.error("Error al obtener la orden:", res.status);
            return res;
        }else{
            const data = await res.json();
            return data ?? null;
            //return res
        }
    } catch (error) {
        //console.error("Error en la petición:", error);
        if (error instanceof Response){
            return error
        }
        throw new Error("Error al obtener la orden.")
    }
}

export async function PutOrder(id: string, payloadPut:PutType){
    //console.log(cliente, total)
    try{
        const res = await fetch(main_access+id, {
            method: 'PUT',
            headers: {
                'Content-Type':'application/json',
            },body: JSON.stringify(payloadPut),
        });

        if(res.ok || res.status == 201 || res.status == 405){
            return res
        }else{
            throw new Error("Error al modificar el cliente.")
        }
    }catch(error){
        if(error instanceof Error){
            return error.message
        }else{
            return error;
        }
    }
    
}