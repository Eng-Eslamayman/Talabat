const API_BASE_URL = 'https://localhost:44364/api'; 

async function handleRegister() {
    const username = document.getElementById('registerUsername').value;
    const email = document.getElementById('registerEmail').value;
    const password = document.getElementById('registerPassword').value;

    const response = await fetch(`${API_BASE_URL}/auth/register`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ username, email, password }),
    });

    if (response.ok) {
        alert('Registration successful! Please login.');
        toggleForms();
    } else {
        alert('Registration failed. Username may already exist.');
    }
}

async function handleLogin() {
    const username = document.getElementById('loginUsername').value;
    const password = document.getElementById('loginPassword').value;

    try {
        const response = await fetch(`${API_BASE_URL}/auth/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ username, password }),
        });

        if (response.ok) {
            const data = await response.json();
            localStorage.setItem('token', data.token); 
            window.location.href = 'shop.html'; 
        } else {
            alert('Login failed. Invalid credentials.');
        }
    } catch (error) {
        console.error('Error during login:', error);
        alert('Failed to connect to the server.');
    }
}

async function createOrder() {
    const productName = document.getElementById('productName').value;
    const quantity = document.getElementById('quantity').value;
    const token = localStorage.getItem('token');

    const response = await fetch(`${API_BASE_URL}/orders`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`,
        },
        body: JSON.stringify({ productName, quantity }),
    });

    if (response.ok) {
        alert('Order created successfully!');
        fetchOrders(); 
    } else {
        alert('Failed to create order.');
    }
}

async function fetchOrders() {
    const token = localStorage.getItem('token');
    const response = await fetch(`${API_BASE_URL}/orders/customer`, {
        method: 'GET',
        headers: {
            'Authorization': `Bearer ${token}`,
        },
    });

    if (response.ok) {
        const orders = await response.json();
        displayOrders(orders);
    } else {
        alert('Failed to fetch orders.');
    }
}

function displayOrders(orders) {
    const ordersContainer = document.getElementById('ordersContainer');
    ordersContainer.innerHTML = '<h2>Your Orders</h2>';

    orders.forEach(order => {
        const orderElement = document.createElement('div');
        orderElement.className = 'order';
        orderElement.innerHTML = `
            <p><strong>Product:</strong> ${order.productName}</p>
            <p><strong>Quantity:</strong> ${order.quantity}</p>
            <p><strong>Date:</strong> ${new Date(order.orderDate).toLocaleString()}</p>
            <button onclick="deleteOrder(${order.id})">Delete</button>
        `;
        ordersContainer.appendChild(orderElement);
    });
}

async function deleteOrder(orderId) {
    const token = localStorage.getItem('token');
    const response = await fetch(`${API_BASE_URL}/orders/${orderId}`, {
        method: 'DELETE',
        headers: {
            'Authorization': `Bearer ${token}`,
        },
    });

    if (response.ok) {
        alert('Order deleted successfully!');
        fetchOrders(); 
    } else {
        alert('Failed to delete order.');
    }
}

function toggleForms() {
    const loginForm = document.getElementById('loginForm');
    const registerForm = document.getElementById('registerForm');
    loginForm.style.display = loginForm.style.display === 'none' ? 'block' : 'none';
    registerForm.style.display = registerForm.style.display === 'none' ? 'block' : 'none';
}

function logout() {
    localStorage.removeItem('token');
    window.location.href = 'index.html';
}

if (window.location.pathname.endsWith('shop.html')) {
    fetchOrders();
}