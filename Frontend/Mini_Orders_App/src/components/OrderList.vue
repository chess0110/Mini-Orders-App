<script setup lang="ts">
import { GetOrders } from '../services/HttpRequests.ts'
import { ref, onMounted } from 'vue';

type OrderType = {
    id: string;
    cliente: string;
    fecha: string;
    total: number;
};

const data = ref<OrderType[]>([])

onMounted( async () => {
    data.value = await GetOrders()
    console.log(data.value)
});

//const ViewId()



</script>

<template>
    <table class="relative justify-center w-full mt-[5px]">
        <caption>
            <div>
                <h2 class="font-bold text-[1.6em] text-left p-[1em] font-family: 'Nunito Sans', helvetica uppercase">Orders Admin Panel</h2>
                <p>a3d228bb-a1b4-40aa-ac9e-8e5ce1f9d7a6</p>
                <button>Add Order</button>
            </div>

        </caption>
        <thead>
            <tr><th class="text-transparent  p-2 text-[1.1em]"></th>
                <th class="border-b-2 border-r-1 border-solid border-[darkgray] p-2 text-[1.1em]"><p>ID</p></th>
                <th class="border-b-2 border-r-1 border-solid border-[darkgray] p-2 text-[1.1em]"><p>Client</p></th>
                <th class="border-b-2 border-r-1 border-solid border-[darkgray] p-2 text-[1.1em]"><p>Date</p></th>
                <th class="border-b-2 border-solid border-[darkgray] p-2 text-[1.1em]"><p>Total</p></th>
                <th class="text-transparent  p-2 text-[1.1em]"></th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="order in data" :key="order.id">
                <td class="">
                    <button class="relative block bg-[#DDDDDD] w-full h-full cursor-pointer m-0 px-0 py-[5px]" id="BtnAccion1">
                    </button>
                </td>
                <td class="border-r-[darkgray] border-r border-solid w-[25%] h-full">
                    <button id="ViewIdBtn" class="relative block bg-[#DDDDDD] w-full h-full cursor-pointer  m-0 px-0 py-[5px]">{{ order.id.slice(0,20) }}...</button>
                </td>
                <td class="border-r-[darkgray] border-r border-solid"><p>{{ order.cliente }}</p></td>
                <td class="border-r-[darkgray] border-r border-solid"><p>{{ order.fecha.slice(0,order.fecha.indexOf("T")) }}</p></td>
                <td class="border-r-[darkgray] border-r border-solid"><p>{{ order.total.toLocaleString() }}</p></td>
                <td>
                    <button class="relative block bg-[#DDDDDD] w-full h-full cursor-pointer shadow-[0px_0px_10px_0px_#DDDDDD] m-0 px-0 py-[5px]" id="BtnAccion2"></button>
                </td>
            </tr>
        </tbody>
    </table>
</template>

<style scoped>
table td tr {
    display: flex;
    justify-content: center;
    flex-wrap: wrap;
    flex-direction: row;
    padding: 5px;
}

table tr td {
    text-align: center;
    /*padding-top: 5px;*/
    /*padding-top: 0.5em;
    padding-bottom: 0.5em;*/
}

#BtnAccion1 {
  width: 100%;
  height: 50px;
  background-color: darkred;
  background-image: url('../assets/trashcan.svg');
  background-size: contain;
  background-repeat: no-repeat;
  background-position: center;
  border-bottom: 1px solid #E6E6E6;
  border-top: 1px solid #E6E6E6;
}

#BtnAccion1:hover {
    border-bottom: 1px solid black;
    border-top: 1px solid black;
    /*padding: 3px 0px 5px 0px;*/
    background-color: #6A0202;
}

#BtnAccion2 {
  width: 100%;
  height: 50px;
  background-color: darkgreen;
  background-image: url('../assets/edit.svg');
  background-size: contain;
  background-repeat: no-repeat;
  background-position: center;
  border-bottom: 1px solid #E6E6E6;
  border-top: 1px solid #E6E6E6;
}

#BtnAccion2:hover {
    border-bottom: 1px solid black;
    border-top: 1px solid black;
    /*padding: 3px 0px 5px 0px;*/
    background-color: #004A00;
}

tbody tr {
    border-bottom: 1px solid #E6E6E6;
}

tbody tr:hover {
    border-bottom: 1px solid gray;

}



caption {
    background-color: #3E685F;
    border-start-end-radius: 25px;
    border-top-left-radius: 25px;
    padding-top: ;
}
caption div {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
}

caption h2 {
    display: inline-block;
    background-color: ;
    color: white;
}
caption p {
    padding-right: 1em;
    padding-left: 1em;
    font-size: 1.6em;
    text-align: center;
    color: white;
}
caption button {
    margin: 0px 1em 0px 1em;
    background-color: #45766B;
    padding: 1em 1.5em 1em 1.5em;
    font-size: 1.3em;
    border-radius: 20px;
    color: white;
    font-weight: bold;
    cursor: pointer;
    border: 1px solid #3E685F;
}

caption button:hover {
    border: 1px solid #2E4B45;
}
</style>
