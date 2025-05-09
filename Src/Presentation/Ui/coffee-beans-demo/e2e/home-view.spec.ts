import { test, expect } from '@playwright/test'

test('has title', async ({ page }) => {
  await page.goto('/')
  await expect(page.getByText('New Arrivals')).toBeVisible()
})
