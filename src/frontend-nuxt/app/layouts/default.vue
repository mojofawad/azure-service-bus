<template>
  <UDashboardGroup>
    <UDashboardSidebar collapsible resizable>
      <template #default="{ collapsed }">
        <UNavigationMenu
          :collapsed="collapsed"
          :items="[
            { label: 'Home', icon: 'i-lucide-house', to: '/' },
            { label: 'Weather', icon: 'i-lucide-sun', to: '/weather' },
          ]"
          orientation="vertical"
        />
      </template>
    </UDashboardSidebar>

    <UDashboardPanel>
      <UDashboardNavbar title="Admin Panel" />
      <slot />
    </UDashboardPanel>
  </UDashboardGroup>
</template>
