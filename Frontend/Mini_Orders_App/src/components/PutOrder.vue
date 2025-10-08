<script setup lang="ts">
import {ref} from "vue"
import { PutOrder } from "../services/HttpRequests"

const props = defineProps<{readonly idFromMain : string; readonly clientFromMain: string; readonly totalFromMain : number}>();


const mensaje = ref<string>("")
const clienteInput = ref(props.clientFromMain)
const totalInput = ref(props.totalFromMain)
/*
type PutType = {
    cliente : string,
    fecha : String,
    total : number
}*/

const addPutRequest = async (id : string) => {
    const cliente : string = clienteInput.value
    const total : number = totalInput.value

    if (!cliente.trim()) {
    mensaje.value = "Cliente no puede estar vacío.";
    return ;
    }

    if (!isNaN(total)){
        //console.log("Es un numero")
        mensaje.value = ""

        const fechaActual = new Date();

        const preparePut = {
        "cliente": cliente.replace(/\s+/g, " ").trim(),
        "fecha": fechaActual.toISOString(),
        "total": total
        };
        
        try {
            const res = await PutOrder(id,preparePut) as Response;
            if (res.ok || res.status == 201) {
                //mensaje.value = res.ok.toString()
                mensaje.value = "Orden actualizada correctamente.";
            } else {
                mensaje.value = `Error: ${res.status}`;
            }
        }catch (error) {
            if(error instanceof Error){
                mensaje.value = "Ocurrio un error durante la solicitud.",error;
            }else{
                mensaje.value = `${error}`;
            }
        }
    }else{
        mensaje.value = "Total debe ser un numero."
        return;
    }
    //console.log(cliente, total)
}

/*
const seeVariables = () => { // Analizando variables para ajustar tipos
    console.log(`
    Id: ${props.idFromMain}
    Cliente: ${clienteInput.value}
    totalInput: ${totalInput.value}`)
}*/

</script>

<template>
<section id="mainPost" class="z-2 h-[62.2vh] relative bg-[#538A7D] flex flex-col items-center gap-[2em] mx-auto my-0">
    <h1 class="text-[white] text-[1.8em]  font-bold">Modify Order</h1>
    <div class="flex justify-center items-center w-[100vw]">
        <label for="inputClient" class="text-[white] text-[1.5em] rounded-[10px] p-[0.5em] px-10 font-bold">ID:</label>
        <input type="text" id="inputClient" placeholder="id: " v-model="props.idFromMain" readonly class="min-w-[450px] bg-[white] w-2/5 text-[1.6em] p-[0.5em] rounded-[10px] text-[#955200] text-center"/>
    </div>
    <div class="flex justify-center items-center w-[100vw]">
        <label for="inputClient" class="text-[white] text-[1.5em] rounded-[10px] p-[0.5em] px-5 font-bold">Client:</label>
        <input type="text" id="inputClient" placeholder="Client: " v-model="clienteInput" class="min-w-[450px] bg-[white] w-2/5 text-[1.6em] p-[0.5em] rounded-[10px]"/>
    </div>
    <div class="flex justify-center items-center w-[100vw]">
        <label for="inputClient" class="text-[white] text-[1.5em] rounded-[10px] p-[0.5em] px-[0.9em] font-bold">Total:</label>
        <input type="number" id="inputTotal" placeholder="Total: " v-model.number="totalInput" class="min-w-[450px] bg-[white] w-2/5 text-[1.6em] p-[0.5em] rounded-[10px]"/>
    </div>
    <button @click="addPutRequest(idFromMain)" class="bg-[#2B4640] text-[1.3em] block w-[30%] text-[white] cursor-pointer p-2.5 rounded-[10px] hover:font-semibold">
        Modify Order</button>
    <p class="text-[#fff] text-[1.3em]">{{ mensaje }}</p>
</section>
</template>

<style scoped>

</style>