<template>
  <TransitionRoot appear :show="isOpen" as="template">
    <Dialog as="div" @close="close" class="relative z-10">
      <TransitionChild
        as="template"
        enter="duration-300 ease-out"
        enter-from="opacity-0"
        enter-to="opacity-100"
        leave="duration-200 ease-in"
        leave-from="opacity-100"
        leave-to="opacity-0"
      >
        <div class="fixed inset-0 bg-black/25" />
      </TransitionChild>

      <div class="fixed inset-0 overflow-y-auto">
        <div class="flex min-h-full items-center justify-center p-4 text-center">
          <TransitionChild
            as="template"
            enter="duration-300 ease-out"
            enter-from="opacity-0 scale-95"
            enter-to="opacity-100 scale-100"
            leave="duration-200 ease-in"
            leave-from="opacity-100 scale-100"
            leave-to="opacity-0 scale-95"
          >
            <DialogPanel
              class="w-full max-w-md transform overflow-hidden rounded-2xl bg-white p-6 text-left align-middle shadow-xl transition-all"
            >
              <DialogTitle
                as="h3"
                class="grid h-12 grid-cols-2 items-center content-stretch gap-60 ... text-lg font-medium leading-6 text-gray-900"
              >
                {{ product?.name }}
                <div class="mt-4 content-end">
                  <button
                    type="button"
                    class="inline-flex justify-center rounded-md border border-transparent bg-blue-100 px-4 py-2 text-sm font-medium text-blue-900 hover:bg-blue-200 focus:outline-none focus-visible:ring-2 focus-visible:ring-blue-500 focus-visible:ring-offset-2"
                    v-on:click="close"
                  >
                    <XMarkIcon class="size-6" aria-hidden="true" />
                  </button>
                </div>
              </DialogTitle>
              <div class="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
                <form class="space-y-6" @submit.prevent="close(purchaseForm)">
                  <input
                    type="hidden"
                    name="productId"
                    id="productId"
                    v-model="purchaseForm.productId"
                    autocomplete="productId"
                    required="true"
                    class="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
                  />
                  <div>
                    <label for="name" class="block text-sm/6 font-medium text-gray-900">Name</label>
                    <div class="mt-2">
                      <input
                        type="text"
                        name="name"
                        id="name"
                        v-model="purchaseForm.name"
                        autocomplete="name"
                        required="true"
                        class="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
                      />
                    </div>
                  </div>
                  <div>
                    <label for="description" class="block text-sm/6 font-medium text-gray-900"
                      >Delivery Address</label
                    >
                    <div class="mt-2">
                      <textarea
                        rows="4"
                        cols="50"
                        name="deliveryAddress"
                        id="deliveryAddress"
                        v-model="purchaseForm.deliveryAddress"
                        autocomplete="deliveryAddress"
                        required="true"
                        class="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
                      >
                      </textarea>
                    </div>
                  </div>
                  <div>
                    <label for="quantity" class="block text-sm/6 font-medium text-gray-900"
                      >Quantity</label
                    >
                    <div class="mt-2">
                      <input
                        type="number"
                        name="quantity"
                        id="quantity"
                        min="1"
                        v-model="purchaseForm.quantity"
                        autocomplete="quantity"
                        required="true"
                        class="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
                      />
                    </div>
                  </div>
                  <input
                    type="hidden"
                    name="cost"
                    id="cost"
                    v-model="purchaseForm.cost"
                    autocomplete="productId"
                    required="true"
                    class="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
                  />
                  <div>
                    <footer class="m-2 h-15 bg-blue-650">
                      <div class="grid h-12 grid-cols-2 items-center content-stretch gap-4 ...">
                        <div>
                          <span
                            class="inline-block bg-gray-200 rounded-full px-3 py-1 text-sm font-semibold text-gray-700"
                            >TotalCost : {{ totalCost }}</span
                          >
                        </div>
                        <div>
                          <button
                            type="submit"
                            class="text-white bg-gradient-to-r from-green-400 via-green-500 to-green-600 hover:bg-gradient-to-br focus:ring-4 focus:outline-none focus:ring-green-300 dark:focus:ring-green-800 font-medium rounded-lg text-sm px-5 py-2.5 text-center me-2 mb-2"
                          >
                            Confirm Purchase
                          </button>
                        </div>
                      </div>
                    </footer>
                  </div>
                </form>
              </div>
            </DialogPanel>
          </TransitionChild>
        </div>
      </div>
    </Dialog>
  </TransitionRoot>
</template>
<script lang="ts">
import { defineComponent } from 'vue'
import { Dialog, DialogPanel, DialogTitle, TransitionChild, TransitionRoot } from '@headlessui/vue'
import { XMarkIcon } from '@heroicons/vue/24/outline'
import type { PurchaseProduct } from '@/models/purchaseProduct'
export default defineComponent({
  name: 'PurchaseComponent',
  components: {
    // eslint-disable-next-line vue/no-reserved-component-names
    Dialog,
    DialogPanel,
    DialogTitle,
    TransitionChild,
    TransitionRoot,
    XMarkIcon,
  },
  data() {
    const ct = parseFloat(this.product?.cost?.trim()?.substring(1) ?? '0')
    return {
      purchaseForm: {
        productId: this.product?.id,
        name: this.product?.name,
        deliveryAddress: '',
        quantity: 0,
        cost: ct,
      } as PurchaseProduct,
    }
  },
  props: ['product', 'isOpen', 'close'],
  computed: {
    totalCost() {
      if (this.product) {
        const flotCost = parseFloat(this.product.cost.trim().substring(1))
        const totalCost = parseFloat((this.purchaseForm.quantity * flotCost).toFixed(2))
        // eslint-disable-next-line vue/no-side-effects-in-computed-properties
        this.purchaseForm.cost = totalCost
        return totalCost
      }
      return 0
    },
  },
})
</script>
