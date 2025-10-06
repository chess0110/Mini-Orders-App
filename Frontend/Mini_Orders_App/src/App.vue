<script setup lang="ts">
import OrderList from './components/OrderList.vue';

</script>

<template>
  <div class="bg-[#2E4B45] text-[white] flex flex-row justify-center p-[1em] shadow-[0px_0px_20px_0px_#2E4B45]">
    <h2 class="text-[2em] font-bold tracking-[1.1px]">Mini Orders App</h2>
  </div>
  <section class="w-[90vw] bg-[#E6E6E6] shadow-[0px_0px_20px_0px_#D1D1D1] mt-[1.8em] mb-0 mx-auto rounded-[25px] h-[80vh] overflow-y-auto">
    <div>
        <OrderList />
    </div>
  </section>

</template>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Nunito+Sans:ital,opsz,wght@0,6..12,200..1000;1,6..12,200..1000&display=swap');
h2 {
  font-family: "Nunito Sans",helvetica;
}
section {
  scrollbar-width: thin;
}


</style>
