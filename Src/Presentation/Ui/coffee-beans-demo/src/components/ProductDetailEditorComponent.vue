<!--becuase of the time limitation i have added most of ui in one component else we can separte as we need
I also used more type sefaty
I possible not add any background color or text color in template it shoud read from theam
I have used tailwind ready made component for stayling
-->
<template>
  <div class="flex min-h-full flex-1 flex-col justify-center px-6 py-12 lg:px-8">
    <LoadingComponent v-if="loading" :loading="loading" class="text-center"></LoadingComponent>
    <div class="sm:mx-auto sm:w-full sm:max-w-sm">
      <h2 class="mt-10 text-center text-2xl/9 font-bold tracking-tight text-gray-900">
        {{ title }}
      </h2>
    </div>
    <div class="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
      <form class="space-y-6" @submit.prevent="handleSubmit(product)">
        <div>
          <label for="name" class="block text-sm/6 font-medium text-gray-900">Name</label>
          <div class="mt-2">
            <input
              type="text"
              name="name"
              id="name"
              v-model="product.name"
              autocomplete="name"
              required="true"
              class="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
            />
          </div>
        </div>
        <div>
          <label for="description" class="block text-sm/6 font-medium text-gray-900"
            >Description</label
          >
          <div class="mt-2">
            <textarea
              rows="4"
              cols="50"
              name="name"
              id="description"
              v-model="product.description"
              autocomplete="description"
              required="true"
              class="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
            >
            </textarea>
          </div>
        </div>
        <div>
          <label for="image" class="block text-sm/6 font-medium text-gray-900">Image</label>
          <div class="mt-2">
            <input
              type="url"
              name="image"
              id="image"
              v-model="product.image"
              autocomplete="image"
              required="true"
              class="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
            />
          </div>
        </div>
        <div>
          <Menu for="colour" as="div" class="relative inline-block text-left">
            <div>
              <MenuButton
                class="inline-flex w-full justify-center gap-x-1.5 rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-xs ring-1 ring-gray-300 ring-inset hover:bg-gray-50"
              >
                Color
                <ChevronDownIcon class="-mr-1 size-5 text-gray-400" aria-hidden="true" />
              </MenuButton>
            </div>

            <transition
              enter-active-class="transition ease-out duration-100"
              enter-from-class="transform opacity-0 scale-95"
              enter-to-class="transform opacity-100 scale-100"
              leave-active-class="transition ease-in duration-75"
              leave-from-class="transform opacity-100 scale-100"
              leave-to-class="transform opacity-0 scale-95"
            >
              <MenuItems
                class="absolute right-0 z-10 mt-2 w-56 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black/5 focus:outline-hidden"
              >
                <div class="py-1">
                  <MenuItem v-for="option in colorOptions" :key="option.value" v-slot="{ active }">
                    <span
                      v-on:click="selectColour(option.value)"
                      :class="[
                        active ? 'bg-gray-100 text-gray-900 outline-hidden' : 'text-gray-700',
                        'block px-4 py-2 text-sm',
                      ]"
                      >{{ option.label }}</span
                    >
                  </MenuItem>
                </div>
              </MenuItems>
            </transition>
          </Menu>
          <div class="mt-0">
            <span v-if="product.colour.length > 0">Selected Color: {{ product.colour }}</span>
          </div>
        </div>
        <div>
          <!-- <label for="country" class="block text-sm/6 font-medium text-gray-900">country</label> -->
          <Menu for="country" as="div" class="relative inline-block text-left">
            <div>
              <MenuButton
                class="inline-flex w-full justify-center gap-x-1.5 rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 shadow-xs ring-1 ring-gray-300 ring-inset hover:bg-gray-50"
              >
                Country
                <ChevronDownIcon class="-mr-1 size-5 text-gray-400" aria-hidden="true" />
              </MenuButton>
            </div>

            <transition
              enter-active-class="transition ease-out duration-100"
              enter-from-class="transform opacity-0 scale-95"
              enter-to-class="transform opacity-100 scale-100"
              leave-active-class="transition ease-in duration-75"
              leave-from-class="transform opacity-100 scale-100"
              leave-to-class="transform opacity-0 scale-95"
            >
              <MenuItems
                class="absolute right-0 z-10 mt-2 w-56 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black/5 focus:outline-hidden"
              >
                <div class="py-1">
                  <MenuItem
                    v-for="option in countryOptions"
                    :key="option.value"
                    v-slot="{ active }"
                  >
                    <span
                      v-on:click="selectCountry(option.value)"
                      :class="[
                        active ? 'bg-gray-100 text-gray-900 outline-hidden' : 'text-gray-700',
                        'block px-4 py-2 text-sm',
                      ]"
                      >{{ option.label }}</span
                    >
                  </MenuItem>
                </div>
              </MenuItems>
            </transition>
          </Menu>
          <div class="mt-0">
            <span v-if="product.country.length > 0">Selected Country: {{ product.country }}</span>
          </div>
        </div>
        <div>
          <label for="isBOTD" class="block text-sm/6 font-medium text-gray-900"
            >Is Bean of the Day(BOTD)</label
          >
          <div class="mt-2">
            <input
              type="checkbox"
              name="isBOTD"
              id="isBOTD"
              v-model="product.isBOTD"
              autocomplete="country"
              class="block rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
            />
          </div>
        </div>
        <div>
          <label for="cost" class="block text-sm/6 font-medium text-gray-900">Cost</label>
          <div class="mt-2">
            <input
              type="text"
              name="cost"
              id="cost"
              v-model="product.cost"
              autocomplete="cost"
              required="true"
              class="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
            />
          </div>
        </div>
        <div>
          <button
            type="submit"
            class="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm/6 font-semibold text-white shadow-xs hover:bg-indigo-500 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
          >
            {{ buttonText }}
          </button>
        </div>
      </form>
    </div>
  </div>
</template>
<script lang="ts">
import { Menu, MenuButton, MenuItem, MenuItems } from '@headlessui/vue'
import { ChevronDownIcon } from '@heroicons/vue/20/solid'
import type { EditableCoffeeBeanProduct } from '@/models/editableCoffeeBeanProduct'
import { defineComponent } from 'vue'
import LoadingComponent from '@/components/LoadingComponent.vue'
export default defineComponent({
  name: 'ProductDetailEditorComponent',
  // eslint-disable-next-line vue/no-reserved-component-names
  components: { Menu, MenuButton, MenuItem, MenuItems, ChevronDownIcon, LoadingComponent },
  props: ['title', 'buttonText', 'editableProduct', 'handleSubmit', 'loading'],
  methods: {
    selectColour(value: string): void {
      this.product.colour = value
    },
    selectCountry(value: string): void {
      this.product.country = value
    },
  },
  data() {
    return {
      product:
        this.editableProduct ??
        ({
          name: '',
          description: '',
          country: '',
          colour: '',
          image: '',
          cost: '',
          isBOTD: false,
        } as EditableCoffeeBeanProduct),
      colorOptions: [
        { value: 'dark roast', label: 'Dark roast' },
        { value: 'golden', label: 'Golden' },
        { value: 'green', label: 'Green' },
        { value: 'light roast', label: 'Light roast' },
        { value: 'medium roast', label: 'Medium roast,' },
      ],
      countryOptions: [
        { value: 'Peru', label: 'Peru' },
        { value: 'Vietnam', label: 'Vietnam' },
        { value: 'Colombia', label: 'Colombia' },
        { value: 'Brazil', label: 'Brazil' },
        { value: 'Honduras', label: 'Honduras' },
      ],
    }
  },
})
</script>
