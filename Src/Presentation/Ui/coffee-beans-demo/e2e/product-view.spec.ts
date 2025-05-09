import { test, expect } from '@playwright/test'

test('Render Product Page', async ({ page }) => {
  await page.goto('/products')
  const gridElement = page.locator('#product-grid')
  await gridElement.isVisible()
})
