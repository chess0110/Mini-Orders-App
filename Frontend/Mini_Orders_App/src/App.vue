<script setup lang="ts">
import OrderList from './components/OrderList.vue';

</script>

<template>
  <header class="bg-[#2E4B45] relative min-w-[1000px] flex-1 text-[white] flex flex-row justify-center p-[1em] shadow-[0px_0px_20px_0px_#2E4B45]">
      <h2 class="text-[2em] font-bold tracking-[1.1px]">Mini Orders App</h2>
  </header>
<section class="min-w-[1000px] min-h-[80vh] shadow-[0px_0px_20px_0px_#D1D1D1] mt-[1.8em] mb-0 rounded-[25px] overflow-hidden"> 
  <div class=" min-h-[85vh] px-[20px] flex flex-col justify-between"> 
    <OrderList /> 
  </div> 
</section>

</template>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Nunito+Sans:ital,opsz,wght@0,6..12,200..1000;1,6..12,200..1000&display=swap');
h2 {
  font-family: "Nunito Sans",helvetica;
}

</style>
