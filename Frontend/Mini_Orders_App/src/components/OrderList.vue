<script setup lang="ts">

</script>

<template>
    <table class="relative justify-center w-full border mt-[5px] border-solid border-[black];">
        <caption class="font-bold text-[1.6em] text-left p-[1.5em] font-family: 'Nunito Sans', helvetica uppercase">Orders Admin Panel</caption>
        <thead>
            <tr>
                <th class="border border-solid border-[black]"><p>ID</p></th>
                <th class="border border-solid border-[black]"><p>Client</p></th>
                <th class="border border-solid border-[black]"><p>Date</p></th>
                <th class="border border-solid border-[black]"><p>Total</p></th>
                <th class="text-transparent border border-solid border-[black]"></th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td><p>prueba id</p></td>
                <td><p>prueba id</p></td>
                <td><p>prueba id</p></td>
                <td><p>prueba id</p></td>
                <td class="w-[10%]">
                    <button class="mx-0.5 hover:bg-[#BBBBBB] bg-[#C5C5C5] cursor-pointer py-1.5 px-2.5">Modificar</button>
                    <button class="mx-0.5 hover:bg-[#BBBBBB] bg-[#C5C5C5] cursor-pointer py-1.5 px-2.5">Eliminar</button>
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
}

table tr td {
    text-align: center;
    padding-top: 0.5em;
    padding-bottom: 0.5em;
}
</style>
