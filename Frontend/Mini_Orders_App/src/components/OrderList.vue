<script setup lang="ts">
import { GetOrders } from '../services/HttpRequests.ts'
import { ref, onMounted, computed } from 'vue';
import AddOrder from './AddOrder.vue'

type OrderType = {
    id: string;
    cliente: string;
    fecha: string;
    total: number;
};

const data = ref<OrderType[]>([])
const currentId = ref()
const currentPage = ref(1);
const itemsPerPage = 12;
const viewAddPost = ref<boolean>(false)


onMounted( async () => {
    data.value = await GetOrders()
    //console.log(data.value)
});


const BtnViewId = (id :string) => {
    if (id == currentId.value){
        currentId.value=""
    }else{
        currentId.value = id
    }
    //console.log(id)
}


const paginatedOrders = computed(() => {
  const start = (currentPage.value - 1) * itemsPerPage;
  const end = start + itemsPerPage;
  return data.value.slice(start, end);
});

const totalPages = computed(() => {
  return Math.ceil(data.value.length / itemsPerPage);
});


const setViewAddPost = () => {
    viewAddPost.value = !viewAddPost.value
}

</script>

<template>
    <AddOrder v-if="viewAddPost"/>
    <table class="relative justify-center w-full mt-[5px] border-[#3E685F]  bg-[#E6E6E6] table-fixed">
        <caption class="bg-[#3E685F] rounded-tl-[25px]">
            <div class="flex flex-row justify-between items-center">
                <h2 class="font-bold text-[1.6em] text-left p-[1em] font-family: 'Nunito Sans', helvetica capitalize inline-block text-[white]">Orders Admin Panel</h2>
                <p class="text-[1.6em] text-center text-[white] px-[1em]">{{currentId }}</p>
                <button @click="setViewAddPost" class="bg-[#579587] text-[1.3em] text-[#1C2D29] font-[bold] cursor-pointer border mx-[1em] my-0 px-[1.5em] py-[1em] rounded-[20px] border-solid border-[#3E685F] hover:border hover:text-[#111C18] hover:border-solid hover:border-[#2E4B45]">
                    Add Order</button>
            </div>
        </caption>
        <thead>
            <tr>
                <th class="text-transparent  p-2 text-[1.1em] border-b-2 border-solid border-[darkgray] w-1/35"></th>
                <th class="border-b-2 border-r-1 border-solid border-[darkgray] p-2 text-[1.1em]"><p>ID</p></th>
                <th class="border-b-2 border-r-1 border-solid border-[darkgray] p-2 text-[1.1em]"><p>Client</p></th>
                <th class="border-b-2 border-r-1 border-solid border-[darkgray] p-2 text-[1.1em]"><p>Date</p></th>
                <th class="border-b-2 border-solid border-[darkgray] p-2 text-[1.1em]"><p>Total</p></th>
                <th class="text-transparent  p-2 text-[1.1em] border-b-2 border-solid border-[darkgray] w-1/35"></th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="order in paginatedOrders" :key="order.id">
                <td class="">
                    <button  id="BtnAccion1" @click="" class="relative block cursor-pointer m-0 px-0 py-[5px] w-full h-[50px] bg-[darkred] bg-[url('../assets/trashcan.svg')] bg-contain bg-no-repeat bg-center border-y-[#E6E6E6] border-b border-solid border-t hover:bg-[#6A0202] hover:border-y-[black] hover:border-b hover:border-solid hover:border-t;">
                    </button>
                </td>
                <td class="border-r-[darkgray] border-r border-solid w-[25%] h-full">
                    <button id="ViewIdBtn" class="relative block bg-[#DDDDDD] w-full h-full cursor-pointer  m-0 px-0 py-[5px] hover:font-[600]" @click="BtnViewId(order.id)">{{ order.id.slice(0,20) }}...</button>
                </td>
                <td class="border-r-[darkgray] border-r border-solid "><p class="whitespace-nowrap overflow-hidden text-ellipsis max-w-[200px]">{{ order.cliente }}</p></td>
                <td class="border-r-[darkgray] border-r border-solid"><p>{{ order.fecha.slice(0,order.fecha.indexOf("T")) }}</p></td>
                <td class=""><p>{{ order.total.toLocaleString() }}</p></td>
                <td>
                    <button id="BtnAccion2" class="relative block cursor-pointer m-0 px-0 py-[5px] w-full h-[50px] bg-[darkgreen] bg-[url('../assets/edit.svg')] bg-contain bg-no-repeat bg-center border-y-[#E6E6E6] border-b border-solid border-t hover:bg-[#004A00] hover:border-y-[black] hover:border-b hover:border-solid hover:border-t;"></button>
                </td>
            </tr>
        </tbody>
    </table>
    <div id="foot" class="flex fixed w-[90vw] flex-row justify-center gap-[1em] bottom-[0.3vh]">
        <button id="goBack" @click="currentPage--" :disabled="currentPage === 1" class="bg-[#2E4B45] bg-no-repeat bg-center w-[5em] h-[50px] cursor-pointer rounded-[10px] hover:bg-[#28423D] hover:p-2.5"></button>
        <button id="goForward" @click="currentPage++" ::disabled="currentPage >= totalPages" class=" bg-[#2E4B45] bg-no-repeat bg-center w-[5em] h-[50px] cursor-pointer rounded-[10px] hover:bg-[#28423D] hover:p-2.5"></button>
    </div>
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
    flex:1;
}

tbody tr {border-bottom: 1px solid #E6E6E6;}

tbody tr:hover {border-bottom: 1px solid gray;}

#BtnAccion1 {background-image: url('../assets/trashcan.svg');}

#BtnAccion2 {background-image: url('../assets/edit.svg');}

#foot #goBack {background-image: url('../assets/back_arrow.svg');}

#foot #goForward {background-image: url('../assets/forward_arrow.svg');}

</style>
