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
        "cliente" : cliente,
        "total" : total
    }
    try {
    const res = await PostOrders(preparePost);
    mensaje.value = res;
    
} catch (error) {
    mensaje.value = "An error has occurred.";
    }

    //console.log(res)

    }else{
        mensaje.value = "Total debe ser un numero."
        return;
    }

    //console.log(cliente, total)
}



</script>

<template>
<div id="mainPost" class="w-[30vw] h-[50vh] absolute z-[1] bg-[#538A7D] flex flex-col items-center gap-[2em] mx-auto my-0 p-[2vw] rounded-[30px] left-[35vw]">
    <h1 class="text-[white] text-[1.8em] font-[bold]">Add Order</h1>
    <input type="text" placeholder="Cliente: " v-model="clienteInput" class="bg-[white] w-4/5 text-[1.6em] p-[0.5em] rounded-[10px]"/>
    <input type="number" placeholder="Total: " v-model.number="totalInput" class="bg-[white] w-4/5 text-[1.6em] p-[0.5em] rounded-[10px]"/>
    <button @click="addPostRequest" class="bg-[#2B4640] text-[1.3em] w-[30%] text-[white] cursor-pointer p-2.5 rounded-[10px] hover:font-semibold">Add CLient</button>
    <p class="text-[#6F4E00] text-[1.3em">{{ mensaje }}</p>
</div>
</template>

<style scoped>

</style>