<script setup lang="ts">
import {ref} from "vue"
import { PostOrders } from "../services/HttpRequests"

const mensaje = ref<string>("")
const clienteInput = ref<string>("")
const totalInput = ref<number>(0)

const addPostRequest = async () => {
    const cliente : string = clienteInput.value
    const total : number = totalInput.value

    if (!cliente.trim()) {
    mensaje.value = "Cliente no puede estar vacío.";
    return;
    }

    if (!isNaN(total)){
        //console.log("Es un numero")
        mensaje.value = ""

        const preparePost = {
        "cliente" : cliente.replace(/\s+/g, " ").trim(),
        "total" : total
        }
        try {
            const res  = await PostOrders(preparePost) as Response;
            if (res.ok || res.status == 201){
                mensaje.value = "Cliente agregado.";  
            }
        
        } catch (error) {
            if (error instanceof Error){
                mensaje.value = "Ocurrio un error durante la solicitud.";
            }else{
                mensaje.value = "Ocurrio un error."
            }
        }

        //console.log(res)

    }else{
        mensaje.value = "Total debe ser un numero."
        return;
    }

    //console.log(`Solicitud actual : ${cliente}__${total}`)
}


</script>

<template>
<section id="mainPost" class="z-2 w-[90vw] h-[62.2vh] relative bg-[#538A7D] flex flex-col items-center gap-[2em] mx-auto my-0 p-[2vw]">
    <h1 class="text-[white] text-[1.8em]  font-bold">Add Order</h1>
    <div class="flex justify-center items-center w-[100vw]">
        <label for="inputClient" class="text-[white] text-[1.5em] rounded-[10px] p-[0.5em] font-bold px-4.5">Client:</label>
        <input type="text" id="inputClient" placeholder="Client: " v-model="clienteInput" class="bg-[white] w-2/5 text-[1.6em] p-[0.5em] rounded-[10px]"/>
    </div>
    <div class="flex justify-center items-center w-[100vw]">
        <label for="inputClient" class="text-[white] text-[1.5em] rounded-[10px] p-[0.5em] px-[0.9em] font-bold">Total:</label>
        <input type="number" id="inputTotal" placeholder="Total: " v-model.number="totalInput" class="bg-[white] w-2/5 text-[1.6em] p-[0.5em] rounded-[10px]"/>
    </div>
    <button @click="addPostRequest" class="bg-[#2B4640] text-[1.3em] block w-[30%] text-[white] cursor-pointer p-2.5 rounded-[10px] hover:font-semibold">Add Order</button>
    <p class="text-[#fff] text-[1.3em]">{{ mensaje }}</p>
</section>
</template>

<style scoped>

</style>