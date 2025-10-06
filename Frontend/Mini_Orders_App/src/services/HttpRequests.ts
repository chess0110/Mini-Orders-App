


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

export async function PostOrders(id : string){
    console.log(id)
}