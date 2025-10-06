


export async function GetOrders(){
    try {
        const res = await fetch('http://localhost:5106/api/Orders')
        const data = await res.json()

        console.log(data)

        if (!data){
            return null
        }else{
            return data
        }

    }catch(error){
        return null
    }

}

type PostType = {
    cliente : string,
    total : number
}

export async function PostOrders(payloadPost:PostType){
    //console.log(cliente, total)
    try{
        const res = await fetch("http://localhost:5106/api/Orders", {
            method: 'POST',
            headers: {
                'Content-Type':'application/json',
            },body: JSON.stringify(payloadPost),
        });

        if(res.ok){
            return "Cliente agregado"
        }else{
            throw new Error("Error al agregar el cliente.")
        }
    }catch(error){
        return error
    }
    
}

export async function DeleteClient(){
    
} 