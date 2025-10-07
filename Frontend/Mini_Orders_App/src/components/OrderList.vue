<script setup lang="ts">
import { DeleteOrder, GetOrders, GetOneOrder } from '../services/HttpRequests.ts';
import { ref, onMounted, computed } from 'vue';
import AddOrder from './AddOrder.vue';
import PutOrder from './PutOrder.vue';
//import PutOrder from './PutOrder.vue';


type OrderType = {
    id: string;
    cliente: string;
    fecha: string;
    total: number;
};

const data = ref<OrderType[]>([])
const dataStatus = ref<boolean>(true)
const oneData = ref<OrderType[]>([])
const currentId = ref()
const currentMessage = ref()
const currentPage = ref(1);
const itemsPerPage = 12;
const viewAddPost = ref<boolean>(false)
const viewAddPut = ref<boolean>(false)
const idToUpdate = ref<string>("")
const searchBarTarget = ref<string>("")
const searchBarStatus = ref<boolean>(false)
const switchFirstSearchBar = ref<boolean>(true)
const currentClientName = ref<string>("")
const currentTotalAmount = ref<number>(0)
const isOneElementTarget = ref<boolean>(false)

onMounted( async () => {
    data.value = await GetOrders()
    //console.log(data.value)
});

const BtnViewId = (id :string) => {
    if (id == searchBarTarget.value){
        searchBarTarget.value = ""
        searchBarStatus.value = false
        switchFirstSearchBar.value = true
    }else{
        currentId.value = ""
        currentMessage.value = ""
        searchBarStatus.value = true
        searchBarTarget.value = id
        switchFirstSearchBar.value = false
    }
    //console.log(id)
}

const paginatedOrders = computed(() => {
    try{
        const start = (currentPage.value - 1) * itemsPerPage;
        const end = start + itemsPerPage;
        return data.value.slice(start, end);   
    }catch(error){
        return;
    }

});

const totalPages = computed(() => {
    try{
        return Math.ceil(data.value.length / itemsPerPage);
    }catch{
        return 0;
    }
});

const setViewAddPost = () => {
    currentMessage.value = ""
    currentId.value = ""
    viewAddPut.value = false
    switchFirstSearchBar.value = true
    searchBarStatus.value = false
    searchBarTarget.value = ""
    viewAddPost.value = !viewAddPost.value
}

const refreshList = async () => {
    if (viewAddPost.value == true){
        data.value = await GetOrders()
        dataStatus.value = true
        viewAddPost.value = false

    }else if(viewAddPut.value == true){
        if(isOneElementTarget.value == true){
            //console.log("Luego de haber buscado un elemento y actualizarlo")
            //console.log(searchBarTarget.value)
            searchById(searchBarTarget.value)
            viewAddPut.value = false
            //dataStatus.value = false
            idToUpdate.value = ""
            currentClientName.value = ""
            currentTotalAmount.value = 0
        }else{
            viewAddPut.value = false
            dataStatus.value = true
            data.value = await GetOrders()
        }
    }else{
        //viewAddPut.value = false
        data.value = await GetOrders()
        dataStatus.value = true
        //console.log("Recargando sin haber abierto post ni put")
    }
    switchFirstSearchBar.value = true
    searchBarTarget.value = ""
    searchBarStatus.value = false
    currentId.value = ""
    currentMessage.value = ""
}

const manageDelete = async (id : string) => {
    searchBarStatus.value = false
    searchBarTarget.value = ""
    viewAddPost.value = false
    if(id){
        const res = await DeleteOrder(id)
        if (res){
            //console.log("El cliente fue eliminado.")
            if(isOneElementTarget.value == true){
                refreshList()
            }else{
                currentId.value = `${id}`
                currentMessage.value = "Deleted: "
                data.value = await GetOrders()
            }

        }else {
            //console.log("El cliente no fue eliminado.")
        }
    }
}

const switchSearchBarStatus = () => {
    viewAddPut.value = false
    viewAddPost.value = false
    currentId.value = ""
    currentMessage.value = ""
    searchBarTarget.value = ""
    switchFirstSearchBar.value = false
    searchBarStatus.value = !searchBarStatus.value
}

const searchById = async (id : string) => {
    //refreshList()
    if (id == "" || id.trim() == "" || id == "x" || id.length <= 30 || !id.includes('-')){
        searchBarTarget.value = ""
        return;
    }
    try{
        const res = await GetOneOrder(id)
        if(res.status == 400 || !res){
            //console.log(404,"mio")
            currentMessage.value = "Id not Found →>"
            return;
        }
        if(res){
            currentMessage.value = ""
            oneData.value = [res]
            dataStatus.value = false 
            isOneElementTarget.value = true
        }else{
            refreshList()
            return res;
        }
    }catch(error){
        refreshList()
        //console.log("404")
        return;
    }
}

const manageUpdate = (id: string, client: string, total: number) => {
    currentClientName.value = client
    currentTotalAmount.value = total
    idToUpdate.value = id

    switchFirstSearchBar.value = true
    searchBarTarget.value = id
    searchBarStatus.value = false
    viewAddPut.value = true

    currentMessage.value = ""
    currentId.value = ""
    //console.log(`idToUpdate: ${idToUpdate} -- id: ${id}`)
}

</script>

<template>

    <table class="relative justify-center w-full mt-[5px] border-[#3E685F]  bg-[#E6E6E6] table-fixed">
        <caption class="bg-[#3E685F] rounded-tl-[25px]">
            <div class="flex flex-row justify-between items-center">
                <h2 class="font-bold text-[1.6em] text-left p-[1em] font-family: 'Nunito Sans', helvetica capitalize inline-block text-[white]">Orders Admin Panel</h2>
                <p class="text-[1.6em] text-center text-[white] px-[1em]"><span class="text-[darkred]">{{currentMessage}}</span><span class="text-[darkorange]">{{currentId}}</span></p>
                
                <div v-if="searchBarStatus" class="p-1 bg-[#E0E0E0] w-[50%] flex justify-between text-[1.6em] rounded-[10px] items-center">
                    <input type="text" v-model="searchBarTarget" placeholder="ID: " class="flex-1 p-4 outline-0 text-[#955200] font-semibold"/>
                    <button id="btnSearchBar" @click="searchById(searchBarTarget)" class="bg-contain bg-no-repeat bg-center bg-[#3E685F] w-[70px] h-[50px] rounded-4xl cursor-pointer hover:bg-[#2E4B45]">
                    </button>
                </div>
                
                <div class="flex flex-row gap-1">
                    <button @click="switchSearchBarStatus" v-if="switchFirstSearchBar" id="searchBtn" class="bg-contain bg-no-repeat bg-center bg-[#3E685F] hover:bg-[#2E4B45] text-[1.3em] text-[#fff] font-[bold] cursor-pointer border mx-[0em] my-0 px-[1.5em] py-[0em] rounded-[20px] border-solid border-[#3E685F] hover:border hover:text-[#111C18] hover:border-solid hover:border-[#2E4B45]">
                        </button>
                    <button @click="refreshList" id="refreshBtn" class="bg-contain bg-no-repeat bg-center bg-[#3E685F] hover:bg-[#2E4B45] text-[1.3em] text-[#fff] font-[bold] cursor-pointer border mx-[0em] my-0 px-[1.5em] py-[1em] rounded-[20px] border-solid border-[#3E685F] hover:border hover:text-[#111C18] hover:border-solid hover:border-[#2E4B45]">
                        </button>
                    <button @click="setViewAddPost" id="addBtn" class="bg-contain bg-no-repeat bg-center bg-[#579587] hover:bg-[#2E4B45] text-[1.3em] text-[#fff] font-[bold] cursor-pointer border mx-[0em] my-0 px-[1.5em] py-[1em] rounded-[20px] border-solid border-[#3E685F] hover:border hover:text-[#111C18] hover:border-solid hover:border-[#2E4B45]">
                        </button>
                </div>
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

            <!-- POST Y PUT-->
            <tr><td>
            <div class="flex absolute flex-col bg-[#538A7D] top-[5.6em] flex-wrap">
                <!-- VISTA PARA POST (INTERFAZ)-->
                <AddOrder v-if="viewAddPost"/>
                <!-- VISTA PARA PUT (INTERFAZ)-->
                <PutOrder v-if="viewAddPut" :idFromMain="idToUpdate" :clientFromMain="currentClientName" :totalFromMain="currentTotalAmount"/>
                <!-- BOTON PARA POST-->
                <button v-if="viewAddPost" id="closeAddOrder" @click="refreshList" class="z-2 bg-[#3E685F] block text-[#fff] text-[2em] font-bold cursor-pointer mx-[0em] my-0 px-[1em] py-[0.4em]  hover:bg-[#375E55] w-[100%]">X</button>
                <!-- BOTON PARA PUT-->
                <button v-if="viewAddPut" id="closeAddOrder" @click="refreshList" class="z-2 bg-[#3E685F] block text-[#fff] text-[2em] font-bold cursor-pointer mx-[0em] my-0 px-[1em] py-[0.4em]  hover:bg-[#375E55] w-[100%]">X</button>
            </div>
            </td></tr>

            <!-- AQUI ABAJO PUSE EL CASO DE VARIOS ELEMENTOS, 'GET ALL ELEMENTS' -->
            <tr v-if="dataStatus" v-for="order in paginatedOrders" :key="order.id">
                <td class="">
                    <button  id="BtnAccion1" @click="manageDelete(order.id)" class="relative block cursor-pointer m-0 px-0 py-[5px] w-full h-[50px] bg-[darkred] bg-contain bg-no-repeat bg-center border-y-[#E6E6E6] border-b border-solid border-t hover:bg-[#6A0202] hover:border-y-[black] hover:border-b hover:border-solid hover:border-t;">
                    </button>
                </td>
                <td class="border-r-[darkgray] border-r border-solid w-[25%] h-full">
                    <button id="ViewIdBtn" class="relative block bg-[#DDDDDD] w-full h-full cursor-pointer  m-0 px-0 py-[5px] hover:font-[600]" @click="BtnViewId(order.id)">{{ order.id.slice(0,20) }}...</button>
                </td>
                <td class="border-r-[darkgray] border-r border-solid text-center"><p class="whitespace-nowrap overflow-hidden text-ellipsis max-w-[200px] text-center">{{ order.cliente }}</p></td>
                <td class="border-r-[darkgray] border-r border-solid"><p>{{ order.fecha.slice(0,order.fecha.indexOf("T")) }}</p></td>
                <td class=""><p>{{ order.total.toLocaleString() }}</p></td>
                <td>
                    <button id="BtnAccion2" @click="manageUpdate(order.id,order.cliente,order.total)" class="relative block cursor-pointer m-0 px-0 py-[5px] w-full h-[50px] bg-[darkgreen] bg-contain bg-no-repeat bg-center border-y-[#E6E6E6] border-b border-solid border-t hover:bg-[#004A00] hover:border-y-[black] hover:border-b hover:border-solid hover:border-t;"></button>
                </td>
            </tr>

            <!-- AQUI ABAJO PUSE EL CASO DE UN ELEMENTO, 'GET ONE ELEMENT BY ID' -->
            <tr v-else v-for="order in oneData" :key="order.id">
                <td class="">
                    <button  id="BtnAccion1" @click="manageDelete(order.id)" class="relative block cursor-pointer m-0 px-0 py-[5px] w-full h-[50px] bg-[darkred] bg-contain bg-no-repeat bg-center border-y-[#E6E6E6] border-b border-solid border-t hover:bg-[#6A0202] hover:border-y-[black] hover:border-b hover:border-solid hover:border-t;">
                    </button>
                </td>
                <td class="border-r-[darkgray] border-r border-solid w-[25%] h-full">
                    <button id="ViewIdBtn" class="relative block bg-[#DDDDDD] w-full h-full cursor-pointer  m-0 px-0 py-[5px] hover:font-[600]" @click="BtnViewId(order.id)">{{ order.id.slice(0,20) }}...</button>
                </td>
                <td class="border-r-[darkgray] border-r border-solid "><p class="whitespace-nowrap overflow-hidden text-ellipsis max-w-[200px]">{{ order.cliente }}</p></td>
                <td class="border-r-[darkgray] border-r border-solid"><p>{{ order.fecha.slice(0,order.fecha.indexOf("T")) }}</p></td>
                <td class=""><p>{{ order.total.toLocaleString() }}</p></td>
                <td>
                    <button id="BtnAccion2" @click="manageUpdate(order.id,order.cliente,order.total)" class="relative block cursor-pointer m-0 px-0 py-[5px] w-full h-[50px] bg-[darkgreen] bg-contain bg-no-repeat bg-center border-y-[#E6E6E6] border-b border-solid border-t hover:bg-[#004A00] hover:border-y-[black] hover:border-b hover:border-solid hover:border-t;"></button>
                </td>
            </tr>


        </tbody>
    </table>
    <div id="foot" class="flex fixed w-[90vw] flex-row justify-center gap-[1em] bottom-[0.3vh]">
        <button v-if="!viewAddPost && !viewAddPut" id="goBack" @click="currentPage--" :disabled="currentPage === 1" class="bg-[#2E4B45] bg-no-repeat bg-center w-[5em] h-[50px] cursor-pointer rounded-[10px] hover:bg-[#28423D] hover:p-2.5"></button>
        <button v-if="!viewAddPost && !viewAddPut" id="goForward" @click="currentPage++" :disabled="currentPage >= totalPages" class=" bg-[#2E4B45] bg-no-repeat bg-center w-[5em] h-[50px] cursor-pointer rounded-[10px] hover:bg-[#28423D] hover:p-2.5"></button>
    </div>
</template>

<style scoped>

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

#searchBtn {background-image: url('../assets/search.svg');}

#refreshBtn{background-image: url('../assets/refresh.svg');}

#addBtn{background-image: url('../assets/add.svg');}

#btnSearchBar {background-image: url('../assets/search.svg');}

</style>
